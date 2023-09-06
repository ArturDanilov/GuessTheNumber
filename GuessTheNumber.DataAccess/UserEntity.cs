namespace GuessTheNumber.DataAccess
{
    public class UserEntity
    {
        public int Id { get; set; }

        public string Nickname { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;
    }
}
