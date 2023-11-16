namespace DMS.az.ViewModels.Contact
{
    public class ContactIndexVM
    {
        public ContactIndexVM()
        {
            Contact = new List<Models.Contact>();
        }

        public List<Models.Contact> Contact { get; set; }
    }
}
