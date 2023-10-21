namespace NzWalks.API.Sealed
{
     public partial  class Seal
    {
        public static int Id { get; set; }
        public static string Name { get; set; }
    }

    //partial class can be inherted and 

   

    public class Test
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? DateOfBirth { get; set; }
        

    }
}
