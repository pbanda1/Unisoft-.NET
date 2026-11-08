using BusinessLayerLogic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using AutoMapper;
using BusinessLayerLogic.DTOs;

namespace BusinessLayerLogic.Services
{
    public class PredmetService : IPredmetService
    {
        private readonly IPredmetRepository _predmetInterface;
        private readonly IMapper _mapper;

        public PredmetService(IPredmetRepository predmetInterface, IMapper mapper)
        {
            _predmetInterface = predmetInterface;
            _mapper = mapper;
        }

        public PredmetDto Create(PredmetCreateDto predmetDTO)
        {
            var predmet = _mapper.Map<Predmet>(predmetDTO);
            var created = _predmetInterface.Create(predmet);
            return _mapper.Map<PredmetDto>(created); 
        }

        public PredmetDto? Delete(int id)
        {
            var deleted = _predmetInterface.Delete(id);
            return deleted == null ? null : _mapper.Map<PredmetDto>(deleted);
        }

        public List<PredmetDto> GetAll()
        => _mapper.Map<List<PredmetDto>>(_predmetInterface.GetAll());

        public PredmetDto? GetByID(int id)
        {
            var predmet = _predmetInterface.GetById(id);
            return predmet == null ? null : _mapper.Map<PredmetDto>(predmet);
        }

        public PredmetWithStudentiDto? GetWithStudenti(int id)
        {
            var predmet = _predmetInterface.GetWithStudenti(id);
            return predmet == null ? null : _mapper.Map<PredmetWithStudentiDto>(predmet);
        }

        public PredmetDto? Update(int id, PredmetUpdateDto predmet)
        {
            var predmetUpdate = _predmetInterface.Update(id, _mapper.Map<Predmet>(predmet)); 
            return predmetUpdate == null ? null : _mapper.Map<PredmetDto>(predmetUpdate);

        }
    }
}
