using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain
{
    public class VideoActor : BaseDomainModel
    {
        //Tabla que contiene la relacion
        public int VideoId { get; set; }
        public int ActorId { get; set; }
    }
}
