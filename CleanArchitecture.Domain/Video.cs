﻿using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain
{
    public class Video : BaseDomainModel
    {        
        public string? Nombre { get; set; }
        public int StreamerId { get; set; }
        public virtual Streamer? Streamer{ get; set; }
        public virtual Director Director { get; set; } //de Uno a uno
        public virtual ICollection<Actor> Actores { get; set; }        

        public Video()
        {
            Actores = new HashSet<Actor>();
        }
           
    }
}
