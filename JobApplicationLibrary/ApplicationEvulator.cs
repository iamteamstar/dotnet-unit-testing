using JobApplicationLibrary.Models;

namespace JobApplicationLibrary
{
	public class ApplicationEvulator
	{

		private const int minAge = 18;
		public ApplicationResult Evulate(JobApplication form)//amaç bu metodu test etmek burası bizim için Unit Of Work yani çalışma alanımız
		{
			if (form.Applicant.Age < minAge)
				return ApplicationResult.AutoRejected;

			return ApplicationResult.AutoAccepted;
		}
	}
	public enum ApplicationResult
	{
		AutoRejected,//başvuru direkt reddedildi
		TransforredToHR,//başvuru hr a gönderildi.ekstra bilgi gereksinimi için
		TransforredToLead,//başvuru lidere gönderildi. teknik mülakat içi
		TransforredToCTO,//başvuru cto ya gönderildi
		AutoAccepted//başvuru oto kabul edildi

	}
}
