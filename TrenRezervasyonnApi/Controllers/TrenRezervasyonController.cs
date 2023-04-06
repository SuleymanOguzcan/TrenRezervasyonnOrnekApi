using Microsoft.AspNetCore.Mvc;
using TrenRezervasyonnApi.Models;

[ApiController]
[Route("[controller]")]
public class TrenRezervasyonController : ControllerBase
{
	[HttpPost]
	public TrenRezervasyonResponse RezervasyonYap(TrenRezervasyonIstek request)
	{
		Tren tren = request.Tren;
		int kisiSayisi = request.RezervasyonYapilacakKisiSayisi;
		bool farkliVagonlaraYerlestirilebilir = request.KisilerFarkliVagonlaraYerlestirilebilir;

		List<VagonYerlesimAyrinti> yerlesimAyrinti = new List<VagonYerlesimAyrinti>();
		bool rezervasyonYapilabilir = false;

		

		if (rezervasyonYapilabilir)
		{
			TrenRezervasyonResponse response = new TrenRezervasyonResponse
			{
				Basarili = true,
				YerlesimAyrinti = yerlesimAyrinti
			};
			return response;
		}
		// Rezervasyon yapýlamazsahata mesajý ile dönecekl
		else
		{
			TrenRezervasyonResponse response = new TrenRezervasyonResponse
			{
				Basarili = false,
				HataMesaji = "Rezervasyon yapilamadi. Bos koltuk yok."
			};
			return response;
		}

		[HttpPost]
		public ActionResult<ReservationResponse> PostReservationRequest(ReservationRequest request)
		{
			var train = _context.Trens
				.Include(t => t.Vagons)
				.SingleOrDefault(t => t.Name == request.Tren.Ad);

			if (train == null)
				return NotFound("Tren bulunamadý.");

			var reservation = new Reservation(train, request.KisilerFarkliVagonlaraYerlestirilebilir, request.RezervasyonYapilacakKisiSayisi);
			var canMakeReservation = reservation.CanMakeReservation();

			if (!canMakeReservation)
				return Ok(new ReservationResponse { RezervasyonYapilabilir = false });
		}
}



	






