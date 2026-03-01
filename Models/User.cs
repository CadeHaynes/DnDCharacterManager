namespace DnDCharacterManager.Models
{
    public class User
    {
        public int Id { get; set; }
        
        //Login info
        public string Username { get; set; }
        public string Password { get; set; }

        //Stored info
        public ICollection<Character> Characters { get; set; } = new List<Character>();
    }
}
