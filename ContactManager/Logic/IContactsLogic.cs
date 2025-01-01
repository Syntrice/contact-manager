namespace ContactManager.Logic
{
    public interface IContactsLogic
    {
        public Task<List<string>> GetEmailAddressCategoryLabelsAsync();
        public Task<List<string>> GetPhoneNumberCategoryLabelsAsync();
    }
}
