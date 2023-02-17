namespace FastEndpointTest.Endpoints.PostWithHeader
{
    public class Endpoint : Endpoint<Request, EmptyResponse>
    {
        public override void Configure()
        {
            Post("/route/path/here");
            AllowAnonymous();
        }

        public override Task HandleAsync(Request r, CancellationToken c)
        {
            return SendAsync(Response);
        }
    }
    public class Request
    {
        [FromHeader("some-header")]
        public string SomeHeader { get; set; }
    }
}