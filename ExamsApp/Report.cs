//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExamsApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class Report
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdExam { get; set; }
        public int Result { get; set; }
    
        public virtual Exam Exam { get; set; }
        public virtual User User { get; set; }
    }
}
