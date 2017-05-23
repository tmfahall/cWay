// Write your Javascript code.
var mainObject;

$.fn.log = function () {
    console.log.apply(console, this);
    return this;
}

function searchVin() {
    console.log("searchVin Called");
    (function ($) {

        var vin = $("#vinToSearch").val().trim();
        console.log("VIN = " + vin);

        var modYear = $("#yearToSearch").val().trim();
        console.log("modYear = " + modYear);

        var yr;
        if (modYear.length > 0) {
            var year = modYear / 1;
            yr = "&modelyear=" + year;
        }
        else {
            yr = "";
        }

        console.log("yr = " + yr)

        $.getJSON('https://vpic.nhtsa.dot.gov/api/vehicles/decodevin/' + vin + '?format=json' + yr, function (data) {

            var results = data.Results;

            var keepers = [];
            var weepers = [];

            var vid;

            var want;

            wants = [5, 18, 26, 28, 29, 37, 41, 42, 63, 111, 135, 145];

            //keeps only the api data that we want
            for (var i = 0; i < results.length; i++) {
                for (var j = 0; j < wants.length; j++) {
                    if (results[i].VariableId == wants[j]) {
                        keepers.push(results[i])
                    }
                }
            }

            for (var i = keepers.length - 1; i >= 0; i--) {
                //clears out any api data that has null values
                if (keepers[i].Value == null) {
                    keepers.splice(i, 1);
                }
            }

            for (var i in keepers) {
                if (keepers[i].VariableId == 18) {
                    ary = keepers[i].Value.split(" ")
                    $("#TruckEngineMake").val(ary[0].trim());

                    ary.splice(0, 1)

                    $("#TruckEngineModel").val(ary.join(" "));
                }

                if (keepers[i].VariableId == 26) {
                    $("#TruckMake").val(keepers[i].Value);
                }

                if (keepers[i].VariableId == 28) {
                    $("#TruckModel").val(keepers[i].Value);
                }

                if (keepers[i].VariableId == 29) {
                    $("#TruckYear").val(keepers[i].Value);
                }

                if (keepers[i].VariableId == 37) {
                    $("#TruckTransmissionType").val(keepers[i].Value);
                }

                if (keepers[i].VariableId == 5) {
                    $("#TruckVehicleType").val(keepers[i].Value);
                }

                if (keepers[i].VariableId == 41) {
                    $("#TruckAxleConfiguration").val(keepers[i].Value);
                }

                if (keepers[i].VariableId == 42) {
                    $("#TruckBrakeType").val(keepers[i].Value);
                }

                if (keepers[i].VariableId == 63) {
                    $("#TruckTransmissionSpeeds").val(keepers[i].Value);
                }

                if (keepers[i].VariableId == 111) {
                    $("#TruckWheelBaseInches").val(keepers[i].Value);
                }

                if (keepers[i].VariableId == 135) {
                    $("#TruckTurbo").val(keepers[i].Value);
                }

                if (keepers[i].VariableId == 145) {
                    $("#TruckAxleConfiguration").val(keepers[i].Value);
                }
            }

            $("#TruckVin").val($("#vinToSearch").val().trim())

            var currentTime = new Date();
            var day = currentTime.getDate();
            var month = currentTime.getMonth() + 1;
            var year = currentTime.getFullYear();

            if (day < 10) {
                day = "0" + day;
            }

            if (month < 10) {
                month = "0" + month;
            }

            var today_date = month + "/" + day + "/" + year;

            $("#CreatedDate").val(today_date.toString())
        })
    })(jQuery)
}

//{"Value":"968","ValueId":"","Variable":"Manufacturer Id","VariableId":157}

function handleTruckFileSelect(evt) {
    var files = evt.target.files;

    for (var i = 0, f; f = files[i]; i++) {
        if (!f.type.match('image.*')) {
            continue;
        }

        var reader = new FileReader();

        reader.onload = (function (theFile) {
            return function (e) {
                var span = document.createElement('span');
                span.innerHTML = ['<img class="thumb" src="', e.target.result, '" title="', escape(theFile.name), '"/>'].join('');
                document.getElementById('truckImagePreview').insertBefore(span, null);

            };
        })(f);

        reader.readAsDataURL(f);
    }
}

function handleTruckPrimaryFileSelect(evt) {
    var files = evt.target.files;

    for (var i = 0, f; f = files[i]; i++) {
        if (!f.type.match('image.*')) {
            continue;
        }

        var reader = new FileReader();

        reader.onload = (function (theFile) {
            return function (e) {
                var span = document.createElement('span');
                span.innerHTML = ['<img class="thumb" src="', e.target.result, '" title="', escape(theFile.name), '"/>'].join('');
                document.getElementById('truckPrimaryPreview').insertBefore(span, null);

            };
        })(f);

        reader.readAsDataURL(f);
    }
}

if ($('#truckImageUpload')) {
    $('#truckImageUpload').change(function () {
        handleTruckFileSelect()
    })
}

if ($('#truckPrimaryImage')) {
    $('#truckPrimaryImage').change(function () {
        handleTruckPrimaryFileSelect()
    })
}

$('#myCarousel').carousel({
    interval: 4000
});

// handles the carousel thumbnails
$('[id^=carousel-selector-]').click(function () {
    var id_selector = $(this).attr("id");
    var id = id_selector.substr(id_selector.length - 1);
    id = parseInt(id);
    $('#myCarousel').carousel(id);
    $('[id^=carousel-selector-]').removeClass('selected');
    $(this).addClass('selected');
});

// when the carousel slides, auto update
$('#myCarousel').on('slid', function (e) {
    var id = $('.item.active').data('slide-number');
    id = parseInt(id);
    $('[id^=carousel-selector-]').removeClass('selected');
    $('[id=carousel-selector-' + id + ']').addClass('selected');
});
