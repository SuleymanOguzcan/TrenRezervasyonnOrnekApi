﻿namespace TrenRezervasyonnApi.Models
{
	public class TrenRezervasyonIstek
	{
		public required Tren Tren { get; set; }
		public int RezervasyonYapilacakKisiSayisi { get; set; }
		public bool KisilerFarkliVagonlaraYerlestirilebilir { get; set; }
	};
