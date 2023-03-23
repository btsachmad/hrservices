using HRServicesAPI.Dto;
using HRServicesAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRServicesAPI.Data
{
    public interface ILeaveRepository
    {
        Task<List<Leave>> GetListByNik(Guid IdEmployee, string? search, int pageSize, int skipAmount);
        Task<List<Leave>> GetListByReviewer(int Level, string? search, int pageSize, int skipAmount);
        Task<int> CountAll();
        Task<Leave> Create(LeaveCreate payload);
        Task<Leave> Approve(LeaveApprove payload);
        Task<Leave> Reject(LeaveReject payload);
    }

    public class LeaveRepository : ILeaveRepository
    {
        private readonly DatabaseContext _dbContext;
        private readonly ILogger<LeaveRepository> _logger;

        public LeaveRepository(DatabaseContext databaseContext, ILogger<LeaveRepository> logger)
        {
            _dbContext = databaseContext;
            _logger = logger;
        }

        public async Task<List<Leave>> GetListByNik(Guid IdEmployee, string? search, int pageSize, int skipAmount)
        {
            var query = _dbContext.Leaves
                .Where(el => el.IdEmployee == IdEmployee)
                .Skip(skipAmount)
                .Take(pageSize);

            if (search != null)
            {
                query = query.Where(
                    b => b.Status == search
                );
            }

            var result = await query.ToListAsync();

            return result;
        }

        public async Task<List<Leave>> GetListByReviewer(int Level, string? search, int pageSize, int skipAmount)
        {
            var query = _dbContext.Leaves
                .Where(el => el.Level == Level)
                .Skip(skipAmount)
                .Take(pageSize);

            if (search != null)
            {
                query = query.Where(
                    b => b.Status == search
                );
            }

            var result = await query.ToListAsync();

            return result;
        }

        public async Task<int> CountAll()
        {
            var result = await _dbContext.Leaves.CountAsync();
            return result;
        }

        public async Task<Leave?> GetDetail(Guid Id)
        {
            var leave = await _dbContext.Leaves
                .Where(b => b.Id == Id)
                .FirstOrDefaultAsync();

            if (leave == null)
                return null;

            return leave;
        }

        public async Task<int> GetTotalLeave(Guid IdEmployee, int Year)
        {
            return await _dbContext.View_LeaveDateSeries
                .Where(
                    el => el.IdEmployee == IdEmployee
                )
                .Where(
                    el => el.Year == Year.ToString()
                )
                .CountAsync();
        }


        public async Task<Leave> Create(LeaveCreate payload)
        {
            // Convert start date string to date format
            DateTime startTime = DateTime.Parse(payload.StartDt);
            DateOnly StartDt = DateOnly.FromDateTime(startTime);

            // Convert end date string to date format
            DateTime endTime = DateTime.Parse(payload.EndDt);
            DateOnly EndDt = DateOnly.FromDateTime(endTime);

            // TODO: check leave history on year of leave (if total leave + current days leave > 12 then reject)            
            var limitLeave = 12;
            var totalLeave = await GetTotalLeave(payload.IdEmployee, startTime.Year);

            var totalDays = (endTime - startTime).TotalDays;
            if (totalDays == 0)
            {
                totalDays = 1;
            }

            // Check if total leave already reach the limit
            totalLeave = (int)(totalLeave + totalDays);
            if (totalLeave > limitLeave)
            {
                throw new InvalidOperationException("Jatah cuti tidak mencukupi");
            }

            // TODO: check matrix based on IdEmployee (if matrix 0 then reject)
            // TODO: check level
            // TODO: check level = MAX then check total days

            Leave NewLeave = new Leave()
            {
                IdEmployee = payload.IdEmployee,
                Level = payload.Level,
                StartDt = StartDt,
                EndDt = EndDt,
                ExpiredDt = payload.ExpiredDt,
                Status = payload.Status,
            };

            _dbContext.Leaves.Add(NewLeave);
            await _dbContext.SaveChangesAsync();

            return NewLeave;
        }

        public async Task<Leave?> Reject(LeaveReject payload)
        {
            var result = await GetDetail(payload.Id);

            if (result == null)
                return null;

            result.ApprovalDt = payload.ApprovalDt;
            result.IdApprover = payload.IdApprover;
            result.Notes = payload.Notes;
            result.Status = payload.Status;

            await _dbContext.SaveChangesAsync();

            return result;
        }

        public async Task<Leave?> Approve(LeaveApprove payload)
        {
            var result = await GetDetail(payload.Id);

            if (result == null)
                return null;

            result.ApprovalDt = payload.ApprovalDt;
            result.IdApprover = payload.IdApprover;
            result.Status = payload.Status;

            await _dbContext.SaveChangesAsync();

            return result;
        }
    }
}
