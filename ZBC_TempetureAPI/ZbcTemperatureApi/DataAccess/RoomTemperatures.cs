//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ZbcTemperatureApi.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class RoomTemperatures
    {
        public int FK_Room_Id { get; set; }
        public int FK_Temperature_Id { get; set; }
        public int Id { get; set; }
    
        public virtual Room Room { get; set; }
        public virtual Temperature Temperature { get; set; }
    }
}
