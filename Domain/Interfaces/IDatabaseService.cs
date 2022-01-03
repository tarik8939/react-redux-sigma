using Domain.Interfaces;

namespace Domain.Functions
{
    public interface IDatabaseService
    {
        public IPost Posts { get; set; }
        public IUser Users { get; set; }
    }
}