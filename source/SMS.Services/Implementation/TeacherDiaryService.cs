using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SMS.DATA.Infrastructure;
using SMS.DTOs.DTOs;
using SMS.Services.Infrastructure;
using SMS.REQUESTDATA.Infrastructure;
using TeacherDiary = SMS.DATA.Models.TeacherDiary;
using DTOTeacherDiary = SMS.DTOs.DTOs.TeacherDiary;
using RequestTeacherDiary = SMS.REQUESTDATA.RequestModels.TeacherDiary;
using System.Text.RegularExpressions;
using SMS.DTOs.ReponseDTOs;

namespace SMS.Services.Implementation
{
    public class TeacherDiaryService : ITeacherDiaryService
    {
        private readonly IRepository<TeacherDiary> _repository;
        private readonly IRequestRepository<RequestTeacherDiary> _requestRepository;
        private readonly IMapper _mapper;
        public TeacherDiaryService(IRepository<TeacherDiary> repository, IRequestRepository<RequestTeacherDiary> requestRepository, IMapper mapper)
        {
            _repository = repository;
            _requestRepository = requestRepository;
            _mapper = mapper;
        }
        #region SMS Section
        public TeacherDiariesList Get(int pageNumber, int pageSize)
        {
            var teacherDiaries = _repository.Get().Where(td => td.IsDeleted == false).OrderByDescending(st => st.DairyDate).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList(); ;
            var teacherDiaryCount = _repository.Get().Count(td => td.IsDeleted == false);
            var teacherDiaryTempList = new List<DTOTeacherDiary>();
            foreach (var teacherDiary in teacherDiaries)
            {
                teacherDiaryTempList.Add(_mapper.Map<TeacherDiary, DTOTeacherDiary>(teacherDiary));
            }
            var teacherDiariesList = new TeacherDiariesList()
            {
                TeacherDiaries = teacherDiaryTempList,
                TeacherDiariesCount = teacherDiaryCount
            };
            return teacherDiariesList;
        }
        public DTOTeacherDiary Get(Guid? id)
        {
            if (id == null) return null;
            var teacherDiaryRecord = _repository.Get().FirstOrDefault(td => td.Id == id && td.IsDeleted == false);
            var teacherDiary = _mapper.Map<TeacherDiary, DTOTeacherDiary>(teacherDiaryRecord);
            return teacherDiary;
        }

        public TeacherDiaryResponse Create(DTOTeacherDiary dtoteacherDiary)
        {
            var validationResult = Validation(dtoteacherDiary);
            if (validationResult.IsError)
            {
                return validationResult;
            }
            dtoteacherDiary.CreatedDate = DateTime.Now;
            dtoteacherDiary.IsDeleted = false;
            dtoteacherDiary.Id = Guid.NewGuid();
            HelpingMethodForRelationship(dtoteacherDiary);
            _repository.Add(_mapper.Map<DTOTeacherDiary, TeacherDiary>(dtoteacherDiary));
            return validationResult;
        }
        public TeacherDiaryResponse Update(DTOTeacherDiary dtoteacherDiary)
        {
            var validationResult = Validation(dtoteacherDiary);
            if (validationResult.IsError)
            {
                return validationResult;
            }
            var teacherDiary = Get(dtoteacherDiary.Id);
            dtoteacherDiary.UpdateDate = DateTime.UtcNow;
            HelpingMethodForRelationship(dtoteacherDiary);
            var mergedTeacherDiary = _mapper.Map(dtoteacherDiary, teacherDiary);
            _repository.Update(_mapper.Map<DTOTeacherDiary, TeacherDiary>(mergedTeacherDiary));
            return validationResult;
        }
        public void Delete(Guid? id, string DeletedBy)
        {
            if (id == null)
                return;
            var teacherDiary = Get(id);
            teacherDiary.IsDeleted = true;
            teacherDiary.DeletedBy = DeletedBy;
            teacherDiary.DeletedDate = DateTime.UtcNow;
            _repository.Update(_mapper.Map<DTOTeacherDiary, TeacherDiary>(teacherDiary));
        }
        private void HelpingMethodForRelationship(DTOTeacherDiary dtoteacherDiary)
        {
            dtoteacherDiary.SchoolId = dtoteacherDiary.School.Id;
            dtoteacherDiary.School = null;
            dtoteacherDiary.InstructorId = dtoteacherDiary.Employee.Id;
            dtoteacherDiary.Employee = null;
        }

        private TeacherDiaryResponse Validation(DTOTeacherDiary dtoteacherDiary)
        {
            //var alphaRegex = new Regex("^[a-zA-Z ]+$");
            //var numericRegex = new Regex("^[0-9]*$");
            var alphanumericRegex = new Regex("^[a-zA-Z0-9 ]*$");
            if (dtoteacherDiary == null)
            {
                return PrepareFailureResponse(dtoteacherDiary.Id,
                    "Invalid",
                    "Object cannot be null"
                    );
            }
            if (string.IsNullOrWhiteSpace(dtoteacherDiary.Name) || dtoteacherDiary.Name.Length > 100)
            {
                return PrepareFailureResponse(dtoteacherDiary.Id,
                    "InvalidName",
                    "Name may null or exceed than 100 characters"
                    );
            }
            if (!alphanumericRegex.IsMatch(dtoteacherDiary.Name))
            {
                return PrepareFailureResponse(dtoteacherDiary.Id,
                   "InvalidName",
                   "Text Field doesn't contain any numbers"
                   );
            }
            if (string.IsNullOrWhiteSpace(dtoteacherDiary.DairyText))
            {
                return PrepareFailureResponse(dtoteacherDiary.Id,
                    "InvalidText",
                    "This field cannot be null"
                    );
            }
            if (!alphanumericRegex.IsMatch(dtoteacherDiary.DairyText))
            {
                return PrepareFailureResponse(dtoteacherDiary.Id,
                   "InvalidName",
                   "Text Field doesn't contain any numbers"
                   );
            }
            if (dtoteacherDiary.DairyDate == null)
            {
                return PrepareFailureResponse(dtoteacherDiary.Id,
                    "InvalidField",
                    "This field cannot be null"
                    );
            }
            if (dtoteacherDiary.School == null)
            {
                return PrepareFailureResponse(dtoteacherDiary.Id,
                    "InvalidField",
                    "This field cannot be null"
                    );
            }
            if (dtoteacherDiary.Employee == null)
            {
                return PrepareFailureResponse(dtoteacherDiary.Id,
                    "InvalidField",
                    "This field cannot be null"
                    );
            }
            return PrepareSuccessResponse(dtoteacherDiary.Id,
                    "NoError",
                    "No Error Found"
                    );
        }
        private TeacherDiaryResponse PrepareFailureResponse(Guid id, string errorMessage, string descriptionMessage)
        {
            return new TeacherDiaryResponse
            {
                Id = id,
                IsError = true,
                StatusCode = "400",
                Message = errorMessage,
                Description = descriptionMessage
            };
        }
        private TeacherDiaryResponse PrepareSuccessResponse(Guid id, string message, string descriptionMessage)
        {
            return new TeacherDiaryResponse
            {
                Id = id,
                IsError = false,
                StatusCode = "200",
                Message = message,
                Description = descriptionMessage
            };
        }
        #endregion

        #region RequestSMS Section
        public TeacherDiariesList RequestGet(int pageNumber, int pageSize)
        {
            var teacherDiaries = _requestRepository.Get().Where(td => td.IsDeleted == false).OrderByDescending(st => st.DairyDate).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList(); ;
            var teacherDiaryCount = _requestRepository.Get().Count(td => td.IsDeleted == false);
            var teacherDiaryTempList = new List<DTOTeacherDiary>();
            foreach (var teacherDiary in teacherDiaries)
            {
                teacherDiaryTempList.Add(_mapper.Map<RequestTeacherDiary, DTOTeacherDiary>(teacherDiary));
            }
            var teacherDiariesList = new TeacherDiariesList()
            {
                TeacherDiaries = teacherDiaryTempList,
                TeacherDiariesCount = teacherDiaryCount
            };
            return teacherDiariesList;
        }
        public DTOTeacherDiary RequestGet(Guid? id)
        {
            if (id == null) return null;
            var teacherDiaryRecord = _requestRepository.Get().FirstOrDefault(td => td.Id == id && td.IsDeleted == false);
            var teacherDiary = _mapper.Map<RequestTeacherDiary, DTOTeacherDiary>(teacherDiaryRecord);
            return teacherDiary;
        }

        public TeacherDiaryResponse RequestCreate(DTOTeacherDiary dtoteacherDiary)
        {
            var validationResult = RequestValidation(dtoteacherDiary);
            if (validationResult.IsError)
            {
                return validationResult;
            }
            dtoteacherDiary.CreatedDate = DateTime.Now;
            dtoteacherDiary.IsDeleted = false;
            dtoteacherDiary.Id = Guid.NewGuid();
            RequestHelpingMethodForRelationship(dtoteacherDiary);
            _requestRepository.Add(_mapper.Map<DTOTeacherDiary, RequestTeacherDiary>(dtoteacherDiary));
            return validationResult;
        }
        public TeacherDiaryResponse RequestUpdate(DTOTeacherDiary dtoteacherDiary)
        {
            var validationResult = RequestValidation(dtoteacherDiary);
            if (validationResult.IsError)
            {
                return validationResult;
            }
            var teacherDiary = Get(dtoteacherDiary.Id);
            dtoteacherDiary.UpdateDate = DateTime.UtcNow;
            RequestHelpingMethodForRelationship(dtoteacherDiary);
            var mergedTeacherDiary = _mapper.Map(dtoteacherDiary, teacherDiary);
            _requestRepository.Update(_mapper.Map<DTOTeacherDiary, RequestTeacherDiary>(mergedTeacherDiary));
            return validationResult;
        }
        public void RequestDelete(Guid? id, string DeletedBy)
        {
            if (id == null)
                return;
            var teacherDiary = Get(id);
            teacherDiary.IsDeleted = true;
            teacherDiary.DeletedBy = DeletedBy;
            teacherDiary.DeletedDate = DateTime.UtcNow;
            _requestRepository.Update(_mapper.Map<DTOTeacherDiary, RequestTeacherDiary>(teacherDiary));
        }
        private void RequestHelpingMethodForRelationship(DTOTeacherDiary dtoteacherDiary)
        {
            dtoteacherDiary.SchoolId = dtoteacherDiary.School.Id;
            dtoteacherDiary.School = null;
            dtoteacherDiary.InstructorId = dtoteacherDiary.Employee.Id;
            dtoteacherDiary.Employee = null;
        }

        private TeacherDiaryResponse RequestValidation(DTOTeacherDiary dtoteacherDiary)
        {
            //var alphaRegex = new Regex("^[a-zA-Z ]+$");
            //var numericRegex = new Regex("^[0-9]*$");
            var alphanumericRegex = new Regex("^[a-zA-Z0-9 ]*$");
            if (dtoteacherDiary == null)
            {
                return RequestPrepareFailureResponse(dtoteacherDiary.Id,
                    "Invalid",
                    "Object cannot be null"
                    );
            }
            if (string.IsNullOrWhiteSpace(dtoteacherDiary.Name) || dtoteacherDiary.Name.Length > 100)
            {
                return RequestPrepareFailureResponse(dtoteacherDiary.Id,
                    "InvalidName",
                    "Name may null or exceed than 100 characters"
                    );
            }
            if (!alphanumericRegex.IsMatch(dtoteacherDiary.Name))
            {
                return RequestPrepareFailureResponse(dtoteacherDiary.Id,
                   "InvalidName",
                   "Text Field doesn't contain any numbers"
                   );
            }
            if (string.IsNullOrWhiteSpace(dtoteacherDiary.DairyText))
            {
                return RequestPrepareFailureResponse(dtoteacherDiary.Id,
                    "InvalidText",
                    "This field cannot be null"
                    );
            }
            if (!alphanumericRegex.IsMatch(dtoteacherDiary.DairyText))
            {
                return RequestPrepareFailureResponse(dtoteacherDiary.Id,
                   "InvalidName",
                   "Text Field doesn't contain any numbers"
                   );
            }
            if (dtoteacherDiary.DairyDate == null)
            {
                return RequestPrepareFailureResponse(dtoteacherDiary.Id,
                    "InvalidField",
                    "This field cannot be null"
                    );
            }
            if (dtoteacherDiary.School == null)
            {
                return RequestPrepareFailureResponse(dtoteacherDiary.Id,
                    "InvalidField",
                    "This field cannot be null"
                    );
            }
            if (dtoteacherDiary.Employee == null)
            {
                return RequestPrepareFailureResponse(dtoteacherDiary.Id,
                    "InvalidField",
                    "This field cannot be null"
                    );
            }
            return RequestPrepareSuccessResponse(dtoteacherDiary.Id,
                    "NoError",
                    "No Error Found"
                    );
        }
        private TeacherDiaryResponse RequestPrepareFailureResponse(Guid id, string errorMessage, string descriptionMessage)
        {
            return new TeacherDiaryResponse
            {
                Id = id,
                IsError = true,
                StatusCode = "400",
                Message = errorMessage,
                Description = descriptionMessage
            };
        }
        private TeacherDiaryResponse RequestPrepareSuccessResponse(Guid id, string message, string descriptionMessage)
        {
            return new TeacherDiaryResponse
            {
                Id = id,
                IsError = false,
                StatusCode = "200",
                Message = message,
                Description = descriptionMessage
            };
        }
        #endregion
    }
}
