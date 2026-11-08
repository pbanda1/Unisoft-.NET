using BusinessLayerLogic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayerLogic.DTOs;
using System.Runtime.CompilerServices;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace BusinessLayerLogic.Services
{
    //pretvara DTO u entitete//
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentInterface;
        
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository studentInterface, IMapper mapper)
{
    _studentInterface = studentInterface;
    _mapper = mapper;
}

        public StudentDto Create(StudentCreateDto dto)
        {
            var student = _mapper.Map<Student>(dto); //mapiranje u studenta, DTO -> entitet (Id je još 0)
            var created = _studentInterface.Create(student); //pretvaranje u entitet iz baze, spremanje u bazu, EF upisuje novi Id 
            return _mapper.Map<StudentDto>(created); //vraćamo dto pozivatelju, entitet -> DTO za kontroler
        }

        public StudentDto? Delete(int id)
        {
            var deleted = _studentInterface.Delete(id);
            return deleted == null ? null : _mapper.Map<StudentDto>(deleted);
        }

        public List<StudentDto> GetAll()
         => _mapper.Map<List<StudentDto>>(_studentInterface.GetAll());

        public StudentDto? GetById(int id)
        {
           var student = _studentInterface.GetById(id); 
           return student == null ? null : _mapper.Map<StudentDto>(student);    

        }

        public StudentWithPredmetiDto? GetWithPredmeti(int id)
        {
            var student = _studentInterface.GetWithPredmeti(id);
            return student == null ? null : _mapper.Map<StudentWithPredmetiDto>(student);   
        }

        public StudentDto? Update(int id, StudentUpdateDto dto)
        {
           var updated = _studentInterface.Update(id, _mapper.Map<Student>(dto));
            return updated == null ? null : _mapper.Map<StudentDto>(updated);
        }
    }
}
