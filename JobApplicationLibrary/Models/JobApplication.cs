namespace JobApplicationLibrary.Models
{
	public class JobApplication//iş başvuruları yapmaya çalıştığımız şey
							   //bir şirketin kendisine yapılan iş başvurularının oto olarak bir filtreden geçirilerek bir sonraki adımı belirten bir fonsks yazmak
	{
		public Applicant Applicant { get; set; }//başvuruyu yapan kişi
		public int YearsOfExperience { get; set; }//başvuranın iş deneyimi
		public List<string> TechStackList { get; set; }//başvuran kişinin bilgileri. mesela yazılımcının kkullandığı teknolojiler
	}
}