using HRServicesAPI.Entities;

namespace HRServicesAPI.Data
{
    public interface IPositionRepository
    {
        List<Position> GetAll();
        Task<Position?> GetDetail(Guid id);
        Task<Position?> Add(Position position);
        Task<Position?> Update(Guid id, Position position);
        Task<Position?> Activate(Guid id);
        Task<Position?> Deactivate(Guid id);
    }

    public class PositionRepository : IPositionRepository
    {
        private readonly DatabaseContext _dbContext;

        public PositionRepository(DatabaseContext databaseContext)
        {
            _dbContext = databaseContext;
        }

        public async Task<Position?> Activate(Guid id)
        {
            var position = await GetDetail(id);

            if (position == null)
                return null;

            position.IsActive = true;

            await _dbContext.SaveChangesAsync();

            return position;
        }

        public async Task<Position?> Add(Position position)
        {
            _dbContext.Positions.Add(position);

            await _dbContext.SaveChangesAsync();

            return position;
        }

        public async Task<Position?> Deactivate(Guid id)
        {
            var position = await GetDetail(id);

            if (position == null)
                return null;

            position.IsActive = false;

            await _dbContext.SaveChangesAsync();

            return position;
        }

        public List<Position> GetAll()
        {
            // var positions =   _dbContext.Positions.ToList();
            // return positions;

            var result = _dbContext.Positions.ToList();
            return result;
        }

        public async Task<Position?> GetDetail(Guid id)
        {
            var position = await _dbContext.Positions.FindAsync(id);

            if (position == null)
                return null;

            return position;
        }

        public async Task<Position?> Update(Guid id, Position position)
        {
            var result = await GetDetail(id);

            if (result == null)
                return null;

            result.Code = position.Code;
            result.Name = position.Name;
            result.Level = position.Level;

            await _dbContext.SaveChangesAsync();

            return result;
        }
    }
}
