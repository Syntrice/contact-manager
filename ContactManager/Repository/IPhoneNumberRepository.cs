using ContactManager.Model;

namespace ContactManager.Repository
{
    public interface IPhoneNumberRepository
    {
        PhoneNumber? AddPhoneNumber(PhoneNumber phoneNumber);
        Task<IEnumerable<PhoneNumber>> GetPhoneNumbersAsync();
        Task<PhoneNumber?> GetPhoneNumberByIdAsync(int id);
        Task<PhoneNumber?> UpdatePhoneNumberAsync(PhoneNumber phoneNumber);
        Task<PhoneNumber?> DeletePhoneNumberByIdAsync(int id);
        Task SaveAsync();
    }
}
