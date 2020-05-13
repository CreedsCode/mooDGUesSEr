using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.ML;
using MooDGUesSErML.Model;

namespace mooDGUesSEr.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly PredictionEnginePool<ModelInput, ModelOutput> _enginePool;

        public IndexModel(ILogger<IndexModel> logger, PredictionEnginePool<ModelInput, ModelOutput> enginePool )
        {
            _logger = logger;
            _enginePool = enginePool;
        }


        public IActionResult OnGetMood([FromQuery]string text)
        {
            if (String.IsNullOrEmpty(text)) return Content("Clear");
            var input = new ModelInput { SentimentText = text };
            var prediction = _enginePool.Predict(input);

            var result = prediction.Prediction switch
            {
                var x when x == false => "Good",
                var x when x == true => "Bad",
            };

            return Content(result);
        }


        public void OnGet(){}

    }

    enum Results
    {
        Bad,
        Happy
    }
}
