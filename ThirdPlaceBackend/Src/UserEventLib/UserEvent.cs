using ThirdPlaceBackend.Src.UserLib;

namespace ThirdPlaceBackend.Src.UserEventLib
{
    public class UserEvent
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required User Creator {  get; set; }
    }
}
