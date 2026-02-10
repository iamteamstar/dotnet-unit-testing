using JobApplicationLibrary.Models;

namespace JobApplicationLibrary
{
	public class ApplicationEvulator
	{

		private const int minAge = 18;
		private const int AutoAcceptedYearsOfExperience = 7;
	
		private List<string> techStackList =new (){ "C#","RabbitMQ","Microservice",".Net","MSSQL"};//JobApplication sınfında kullanıcının kullandığı teknolojileri isteyen TechStackList attribute ü ile ilgili testler yazacağız. amacımız burada belirttiğimiz araç ve dilleri biliyor olmasını beklemek.Dışarıdan gelen liste ile kaç tanesinin uyuştuğua bakacağız


		public ApplicationResult Evulate(JobApplication form)//amaç bu metodu test etmek burası bizim için Unit Of Work yani çalışma alanımız
		{
			if (form.Applicant.Age < minAge)
				return ApplicationResult.AutoRejected;
			var sr = GetTechSimilatarityRate(form.TechStackList);//bize gönderilen fotmun techStackListini gönderdik
			if (sr < 20)
				return ApplicationResult.AutoRejected;//benzerlik oranı %25 in altındaysa oto red
			if (sr >= 80 && form.YearsOfExperience>=AutoAcceptedYearsOfExperience)
				return ApplicationResult.AutoAccepted;//gönderilen form ile istenilen özelliklerdeki benzerlik %75ten fazla ve tecrübe 7 yıldan fazla ise oto kabul edilsin
			if (sr >= 25 && sr <= 80)
				return ApplicationResult.TransforredToHR;//hr a eksik bilgi için gönderilsin ve yıllık deneyimine bakılsın

			return ApplicationResult.AutoAccepted;
		}
		public int GetTechSimilatarityRate(List<string>techStacks)//iki listede kaç tane eleman birbirine benziyor bunu bulacak fonk
		{
			var matchedCount =
				techStacks.Where(x => techStackList.Contains(x, StringComparer.OrdinalIgnoreCase))//amaç büyük-küçük harfe takılmamak
					.Count();//amaç benzeyenlerin sayısını bulmak
			return (int)((double)matchedCount / techStackList.Count) * 100;//amaç geriye bir yüzdelik döndürmek
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
