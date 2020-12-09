namespace P02_HospitalDatabase.Data.Models
{
    public partial class PatientMedicament
    {
        public int Patientid { get; set; }

        public int MedicamentId { get; set; }

        public virtual Patient  Patient{ get; set; }

        public virtual Medicament Medicament { get; set; }
    }
}
