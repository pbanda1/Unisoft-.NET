using BusinessLayerLogic.Exceptions;
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
    public class StudentPredmetService : IStudentPredmetService
    {

        private readonly IStudentPredmetInterface _studentPredmetInterface;
        private readonly IStudentRepository _studentInterface;
        private readonly IPredmetRepository _predmetInterface;
        private readonly IMapper _mapper;

        public StudentPredmetService(
            IStudentPredmetInterface studentPredmetInterface,
            IStudentRepository studentInterface,
            IPredmetRepository predmetInterface,
            IMapper mapper
            )
        {
            _studentPredmetInterface = studentPredmetInterface;
            _studentInterface = studentInterface;
            _predmetInterface = predmetInterface;
            _mapper = mapper;
        }

        public StudentPredmetDto Create(StudentPredmetCreateDto dto)
        {
            if (_studentInterface.GetById(dto.StudentID) == null)
                throw new NotFoundException($"Student {dto.StudentID} does not exist");

            if (_predmetInterface.GetById(dto.PredmetID) == null)
                throw new NotFoundException($"Predmet {dto.PredmetID} does not exist");

            if (_studentPredmetInterface.GetByID(dto.StudentID, dto.PredmetID) != null)
                throw new ConflictException("Student is already assigned to the subject");

            var created = _studentPredmetInterface.Create(_mapper.Map<StudentPredmet>(dto));
            return _mapper.Map<StudentPredmetDto>(created);
        }

        public StudentPredmetDto? Delete(int studentID, int predmetID)
        {
           var deleted = _studentPredmetInterface.Delete(studentID, predmetID);
           return deleted == null ? null : _mapper.Map<StudentPredmetDto>(deleted);
        }

        public List<StudentPredmetDto> GetAll()
        => _mapper.Map<List<StudentPredmetDto>>(_studentPredmetInterface.GetAll());

        public StudentPredmetDto? GetByID(int studentID, int predmetID)
        {
            var studentPredmet = _studentPredmetInterface.GetByID(studentID, predmetID);
            return studentPredmet == null ? null : _mapper.Map<StudentPredmetDto>(studentPredmet);
        }
    }
}
