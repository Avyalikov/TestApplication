//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class orders
    {
        public int UserId { get; set; }
        public string Desc { get; set; }
        public Nullable<System.DateTime> Odate { get; set; }
        public Nullable<int> Cnt { get; set; }
    
        public virtual users users { get; set; }
    }
}
