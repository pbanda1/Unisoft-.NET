using BusinessLayerLogic.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayerLogic.Interface
{
    public interface IPredmetService
    {
        List<PredmetDto> GetAll();

        PredmetDto? GetByID(int id);

        PredmetDto Create(PredmetCreateDto predmet);

        PredmetDto? Update(int id, PredmetUpdateDto predmet);

        PredmetDto? Delete(int id);

        PredmetWithStudentiDto? GetWithStudenti(int id);
    }
}
