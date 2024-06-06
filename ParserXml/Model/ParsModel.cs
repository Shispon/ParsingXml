using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserXml.Model
{
    class ProfessionalStandart
    {
        public string? NameProfessionalStandart { get; set; }
        public string? RegistrationNumber { get; set; }
        public string? OrderNumber { get; set; }
        public string? DateOfApproval { get; set; }
        public FirstSection? FirstSection { get; set; }
    }

    class FirstSection
    {
        public string? KindProfessionalActivity { get; set; }
        public string? CodeKindProfessionalActivity { get; set; }
        public string? PurposeKindProfessionalActivity { get; set; }
        public EmploymentGroup? EmploymentGroup { get; set; }
    }

    class EmploymentGroup
    {
        public List<UnitOKZ>? ListOKZ { get; set; }
        public List<UnitOKVED>? ListOKVED { get; set; }
    }

    class UnitOKZ
    {
        public string? CodeOKZ { get; set; }
        public string? NameOKZ { get; set; }
    }

    class UnitOKVED
    {
        public string? CodeOKVED { get; set; }
        public string? NameOKVED { get; set; }
    }
}
