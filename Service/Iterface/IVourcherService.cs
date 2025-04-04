﻿using ProjectPrn222.Models;

namespace ProjectPrn222.Service.Iterface
{
	public interface IVourcherService
	{
		void AddVourcher(Vourcher vourcher);
		void UpdateVourcher(Vourcher vourcher);
		Vourcher? GetVourcher(string code);
		Vourcher? GetVourcherByCode(string code);
        IQueryable<Vourcher> SearchVourcher(string keyword);
        IQueryable<Vourcher> GetAllVourchers();
    }
}
