using AutoMapper;
using Laboratory.Services.TestParameterAPI.Data;
using Laboratory.Services.TestParameterAPI.Models;
using Laboratory.Services.TestParameterAPI.Models.Dto;
using Microsoft.AspNetCore.Mvc;


namespace Laboratory.Services.ParameterAPI.Controllers
{
    [Route("api/parameter")]
    [ApiController]
    public class ParameterParameterController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _response;
        private IMapper _mapper;

        public ParameterParameterController(AppDbContext db, IMapper mapper)
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
                IEnumerable<Parameter> objList = _db.parameters.ToList();
                _response.Result = _mapper.Map<IEnumerable<ParameterDto>>(objList);

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
                Parameter obj = _db.parameters.First(u => u.Id == id);
                _response.Result = _mapper.Map<ParameterDto>(obj);
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
        public ResponseDto Post([FromBody] ParameterDto ParameterDto)
        {
            try
            {
                Parameter obj = _mapper.Map<Parameter>(ParameterDto);
                _db.parameters.Add(obj);
                _db.SaveChanges();

                _response.Result = _mapper.Map<ParameterDto>(obj);
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.Message = e.Message;
            }
            return _response;

        }
        //[HttpPut]
        //public ResponseDto Update([FromBody] ParameterDto ParameterDto)
        //{
        //    try
        //    {
        //        Parameter obj = _mapper.Map<Parameter>(ParameterDto);
        //        _db.parameters.Update(obj); 
        //        _db.SaveChanges();

        //        _response.Result = _mapper.Map<ParameterDto>(obj);
        //    }
        //    catch (Exception e)
        //    {
        //        _response.IsSuccess = false;
        //        _response.Message = e.Message;
        //    }
        //    return _response;
        //}

        [HttpPut]
        public ResponseDto Update([FromBody] ParameterDto parameterDto)
        {
            try
            {
                Parameter obj = _mapper.Map<Parameter>(parameterDto);
                _db.parameters.Update(obj);
                _db.SaveChanges();
                _response.Result = _mapper.Map<ParameterDto>(obj);
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.Message = e.Message;
            }
            return _response;

        }
        //[HttpDelete]
        //[Route("{id:int}")]
        //public ResponseDto Delete(int id)
        //{
        //    try
        //    {
        //        Parameter obj = _db.parameters.First(u => u.ParameterId == id);
        //        _db.parameters.Remove(obj);
        //        _db.SaveChanges();

        //        _response.Result = _mapper.Map<ParameterDto>(obj);
        //    }
        //    catch (Exception e)
        //    {
        //        _response.IsSuccess = false;
        //        _response.Message = e.Message;
        //    }
        //    return _response;

        //}
    }
}

