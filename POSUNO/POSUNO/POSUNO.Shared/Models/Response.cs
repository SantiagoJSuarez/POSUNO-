
namespace POSUNO.Models
{
    class Response
    {
        public bool  IsSuccess { get; set; } //funciona (Si o no)

        public string  Message  { get; set; } //mensaje

        public object  Result { get; set; } // resultado generico

    }
}
