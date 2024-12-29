using AutoMapper;
using Laboratory.Services.TestAPI.Data;
using Laboratory.Services.TestAPI.Models;
using Laboratory.Services.TestAPI.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Laboratory.Services.TestAPI.Controllers
{
    [Route("api/Test")]
    [ApiController]
   // [Authorize]
    public class TestAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _response;
        private IMapper _mapper;

        public TestAPIController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new ResponseDto();
        }

        [HttpGet]
        
        public ResponseDto Get()
        {
            try
            {
                IEnumerable<Test> objList = _db.tests.ToList();
                _response.Result = _mapper.Map<IEnumerable<TestDto>>(objList);

            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.Message = e.Message;
            }
            return _response;

        }


        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto Get(int id)
        {
            try
            {
                Test obj = _db.tests.First(u => u.TestId == id);
                _response.Result = _mapper.Map<TestDto>(obj);
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.Message = e.Message;
            }
            return _response;

        }

        [HttpPost]
        //[Authorize(Roles ="Admin")]
        public ResponseDto Post([FromBody] TestDto TestDto)
        {
            try
            {
                Test obj = _mapper.Map<Test>(TestDto);
                _db.tests.Add(obj);
                _db.SaveChanges();

                _response.Result = _mapper.Map<TestDto>(obj);
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.Message = e.Message;
            }
            return _response;

        }
        [HttpPut]
        public ResponseDto Update([FromBody] TestDto TestDto)
        {
            try
            {
                Test obj = _mapper.Map<Test>(TestDto);
                _db.tests.Update(obj);
                _db.SaveChanges();

                _response.Result = _mapper.Map<TestDto>(obj);
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.Message = e.Message;
            }
            return _response;

        }
        [HttpDelete]
        [Route("{id:int}")]
        public ResponseDto Delete(int id)
        {
            try
            {
                Test obj = _db.tests.First(u => u.TestId == id);
                _db.tests.Remove(obj);
                _db.SaveChanges();

                _response.Result = _mapper.Map<TestDto>(obj);
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.Message = e.Message;
            }
            return _response;

        }
    }
}
