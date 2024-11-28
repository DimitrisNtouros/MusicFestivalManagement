using MusicFestivalManagement.Models;
using MusicFestivalManagement.Repository;
using MusicFestivalManagement.Repository.Interfaces;

namespace MusicFestivalManagement.Service
{
    public class PerformanceService
    {
        private readonly IPerformanceRepository _repository;
        private readonly IArtistRepository _artistRepository;

        public PerformanceService(IPerformanceRepository repository, IArtistRepository artistRepository)
        {
            _repository = repository;
            _artistRepository = artistRepository;
        }

        public async Task<Performance> CreatePerformanceAsync(Performance performance, string creatorName)
        {
            // Έλεγχος για μοναδικότητα του ονόματος
            if (!await _repository.IsPerformanceNameUniqueAsync(performance.Name, performance.FestivalId))
            {
                throw new Exception("Performance name must be unique within the festival.");
            }

            performance.CreationDate = DateTime.UtcNow;
            performance.State = "CREATED";

            var mainArtist = new Artist
            {
                Name = creatorName,
                Role = "Main Artist"
            };

            performance.Artists.Add(mainArtist);

            await _repository.AddPerformanceAsync(performance);

            return performance;
        }

        public async Task<IEnumerable<Performance>> GetAllPerformancesAsync()
        {
            return await _repository.GetAllPerformancesAsync();
        }

        public async Task<Performance> GetPerformanceByIdAsync(int id)
        {
            return await _repository.GetPerformanceByIdAsync(id);
        }

        public async Task UpdatePerformanceAsync(Performance performance)
        {
            await _repository.UpdatePerformanceAsync(performance);
        }

        public async Task DeletePerformanceAsync(int id)
        {
            await _repository.DeletePerformanceAsync(id);
        }

        public async Task<IEnumerable<Performance>> GetPerformancesByFestivalIdAsync(int festivalId)
        {
            return await _repository.GetPerformancesByFestivalIdAsync(festivalId);
        }
    }

}
