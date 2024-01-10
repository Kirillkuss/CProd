namespace CProd;

public class BaseResponse{

    public int Code {get; set;}
    public string Message {get; set;} = null!;

    public BaseResponse(){
    }
    public BaseResponse(int Code, string Message){
        this.Code = Code;
        this.Message = Message;
    }


}