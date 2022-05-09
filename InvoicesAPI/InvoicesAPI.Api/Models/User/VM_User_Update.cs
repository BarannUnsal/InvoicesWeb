namespace InvoicesAPI.Api.Models.User
{
    public class VM_User_Update
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public long TcNo { get; set; }
        public string Email { get; set; }
        public bool isHaveCar { get; set; }
        public string CarPlate { get; set; }
    }
}
