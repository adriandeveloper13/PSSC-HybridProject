//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using University.Common;

namespace University.DataLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class SchoolSubjects : IDatabaseObjectEntity
    {
        public System.Guid Id { get; set; }
        public string Name { get; set; }
        public int ExamProportion { get; set; }
        public int Credits { get; set; }
        public string EvaluationType { get; set; }
    }
}
