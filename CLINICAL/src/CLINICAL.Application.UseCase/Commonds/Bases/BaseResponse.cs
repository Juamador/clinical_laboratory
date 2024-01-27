﻿namespace CLINICAL.Application.UseCase.Commonds.Bases
{
    public class BaseResponse<T>
    {
        public bool IsSuccess {  get; set; }
        public T? Data { get; set; }
        public IEnumerable<BaseError>? Errors { get; set; }
    }
}
