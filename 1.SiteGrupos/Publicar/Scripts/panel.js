

function myFunction() {
    document.getElementById("myDropdown").style.display = 'block';
}

function closeWin() {
    document.getElementById("myDropdown").style.display = 'none';   // Closes the new window
}

function prueba(valor) {
    /**Botón vuelos    #FF0080*/
    if (valor == 1) {
        document.getElementById("VuelosLi").style.backgroundColor = '#FF0080';
        document.getElementById("HotelLi").style.backgroundColor = '#6101d1';
        document.getElementById("HotelVueloLi").style.backgroundColor = '#6101d1';
        document.getElementById("AutoLi").style.backgroundColor = '#6101d1';
        document.getElementById("CruceroLi").style.backgroundColor = '#6101d1';
        document.getElementById("TransladosLi").style.backgroundColor = '#6101d1';
        document.getElementById("ActividadesLi").style.backgroundColor = '#6101d1';
        document.getElementById("ptw-container").style.display = 'block'
        var stringHtml = '<script type="text/javascript" src="https://widgets.priceres.co/gruposco/jsonpBooker/startWidget?container=ptw-container&UseConfigs=true&CurrentSection=2&CurrentEngine=2&ShowProducts=false&EngineConfigs[0].Engine=2&SectionConfigs[0].SectionTab=2&SectionConfigs[0].DefaultEngine=2&IsHorizontal=true"></script>'; //Vuelos
        $('#ptw-container').append(stringHtml)
    }
    /*Botón Hotel*/
    if (valor == 2) {
        document.getElementById("VuelosLi").style.backgroundColor = '#6101d1';
        document.getElementById("HotelLi").style.backgroundColor = '#FF0080';
        document.getElementById("HotelVueloLi").style.backgroundColor = '#6101d1';
        document.getElementById("AutoLi").style.backgroundColor = '#6101d1';
        document.getElementById("CruceroLi").style.backgroundColor = '#6101d1';
        document.getElementById("TransladosLi").style.backgroundColor = '#6101d1';
        document.getElementById("ActividadesLi").style.backgroundColor = '#6101d1';
        document.getElementById("ptw-container").style.display = 'block'
        var stringHtml = '<script type="text/javascript" src="https://widgets.priceres.co/gruposco/jsonpBooker/startWidget?container=ptw-container&UseConfigs=true&CurrentSection=1&CurrentEngine=1&ShowProducts=false&EngineConfigs[0].Engine=1&SectionConfigs[0].SectionTab=1&SectionConfigs[0].DefaultEngine=1"></script>';
        $('#ptw-container').append(stringHtml)
    }
    /*Boton Hotel + vuelo*/
    if (valor == 3) {
        document.getElementById("VuelosLi").style.backgroundColor = '#6101d1';
        document.getElementById("HotelLi").style.backgroundColor = '#6101d1';
        document.getElementById("HotelVueloLi").style.backgroundColor = '#FF0080';
        document.getElementById("AutoLi").style.backgroundColor = '#6101d1';
        document.getElementById("CruceroLi").style.backgroundColor = '#6101d1';
        document.getElementById("TransladosLi").style.backgroundColor = '#6101d1';
        document.getElementById("ActividadesLi").style.backgroundColor = '#6101d1';
        document.getElementById("ptw-container").style.display = 'block'
        var stringHtml = '<script type="text/javascript" src="https://widgets.priceres.co/gruposco/jsonpBooker/startWidget?container=ptw-container&UseConfigs=true&CurrentSection=3&CurrentEngine=3&ShowProducts=false&EngineConfigs[0].Engine=3&EngineConfigs[1].Engine=8&SectionConfigs[0].SectionTab=3&SectionConfigs[0].DefaultEngine=3&IsHorizontal=true"></script>';
        $('#ptw-container').append(stringHtml)
    }
    /*Boton Autos*/
    if (valor == 4) {
        document.getElementById("VuelosLi").style.backgroundColor = '#6101d1';
        document.getElementById("HotelLi").style.backgroundColor = '#6101d1';
        document.getElementById("HotelVueloLi").style.backgroundColor = '#6101d1';
        document.getElementById("AutoLi").style.backgroundColor = '#FF0080';
        document.getElementById("CruceroLi").style.backgroundColor = '#6101d1';
        document.getElementById("TransladosLi").style.backgroundColor = '#6101d1';
        document.getElementById("ActividadesLi").style.backgroundColor = '#6101d1';
        document.getElementById("ptw-container").style.display = 'block'
        var stringHtml = '<script type="text/javascript" src="https://widgets.priceres.co/gruposco/jsonpBooker/startWidget?container=ptw-container&UseConfigs=true&CurrentSection=6&CurrentEngine=6&ShowProducts=false&EngineConfigs[0].Engine=6&SectionConfigs[0].SectionTab=6&SectionConfigs[0].DefaultEngine=6&IsHorizontal=true"></script>'; //Autos
        $('#ptw-container').append(stringHtml)
    }
    /*Boton Crucero*/
    if (valor == 5) {
        document.getElementById("VuelosLi").style.backgroundColor = '#6101d1';
        document.getElementById("HotelLi").style.backgroundColor = '#6101d1';
        document.getElementById("HotelVueloLi").style.backgroundColor = '#6101d1';
        document.getElementById("AutoLi").style.backgroundColor = '#6101d1';
        document.getElementById("CruceroLi").style.backgroundColor = '#FF0080';
        document.getElementById("TransladosLi").style.backgroundColor = '#6101d1';
        document.getElementById("ActividadesLi").style.backgroundColor = '#6101d1';
        document.getElementById("ptw-container").style.display = 'block'
        var stringHtml = '<script type="text/javascript" src="https://widgets.priceres.co/gruposco/jsonpBooker/startWidget?container=ptw-container&UseConfigs=true&CurrentSection=9&CurrentEngine=9&ShowProducts=false&EngineConfigs[0].Engine=9&SectionConfigs[0].SectionTab=9&SectionConfigs[0].DefaultEngine=9&IsHorizontal=true"></script>'; //Cruceros
        $('#ptw-container').append(stringHtml)
    }
    /*Boton Translados*/
    if (valor == 6) {
        document.getElementById("VuelosLi").style.backgroundColor = '#6101d1';
        document.getElementById("HotelLi").style.backgroundColor = '#6101d1';
        document.getElementById("HotelVueloLi").style.backgroundColor = '#6101d1';
        document.getElementById("AutoLi").style.backgroundColor = '#6101d1';
        document.getElementById("CruceroLi").style.backgroundColor = '#6101d1';
        document.getElementById("TransladosLi").style.backgroundColor = '#FF0080';
        document.getElementById("ActividadesLi").style.backgroundColor = '#6101d1';
        document.getElementById("ptw-container").style.display = 'block'
        var stringHtml = '<script type="text/javascript" src="https://widgets.priceres.co/gruposco/jsonpBooker/startWidget?container=ptw-container&UseConfigs=true&CurrentSection=4&CurrentEngine=4&ShowProducts=false&EngineConfigs[0].Engine=4&SectionConfigs[0].SectionTab=4&SectionConfigs[0].DefaultEngine=4&IsHorizontal=true"></script>'; //Traslados
        $('#ptw-container').append(stringHtml)
    }
    /*Boton Tours*/
    if (valor == 7) {
        document.getElementById("VuelosLi").style.backgroundColor = '#6101d1';
        document.getElementById("HotelLi").style.backgroundColor = '#6101d1';
        document.getElementById("HotelVueloLi").style.backgroundColor = '#6101d1';
        document.getElementById("AutoLi").style.backgroundColor = '#6101d1';
        document.getElementById("CruceroLi").style.backgroundColor = '#6101d1';
        document.getElementById("TransladosLi").style.backgroundColor = '#6101d1';
        document.getElementById("ActividadesLi").style.backgroundColor = '#FF0080';
        document.getElementById("ptw-container").style.display = 'block'
        var stringHtml = '<script type="text/javascript" src="https://widgets.priceres.co/gruposco/jsonpBooker/startWidget?container=ptw-container&UseConfigs=true&CurrentSection=5&CurrentEngine=5&ShowProducts=false&EngineConfigs[0].Engine=5&SectionConfigs[0].SectionTab=5&SectionConfigs[0].DefaultEngine=5&IsHorizontal=true"></script>'; //Traslados
        $('#ptw-container').append(stringHtml)
    }
    /*Boton Grupos*/
    if (valor == 8) {
        document.getElementById("VuelosLi").style.backgroundColor = '#6101d1';
        document.getElementById("HotelLi").style.backgroundColor = '#6101d1';
        document.getElementById("HotelVueloLi").style.backgroundColor = '#6101d1';
        document.getElementById("AutoLi").style.backgroundColor = '#6101d1';
        document.getElementById("CruceroLi").style.backgroundColor = '#6101d1';
        document.getElementById("TransladosLi").style.backgroundColor = '#6101d1';
        document.getElementById("ActividadesLi").style.backgroundColor = '#6101d1';
        document.getElementById("ptw-container").style.display = 'none'
    }
    //Boton Grupos Corporativo
    if (valor == 9) {
        document.getElementById("VuelosLi").style.backgroundColor = '#6101d1';
        document.getElementById("HotelLi").style.backgroundColor = '#6101d1';
        document.getElementById("HotelVueloLi").style.backgroundColor = '#6101d1';
        document.getElementById("AutoLi").style.backgroundColor = '#6101d1';
        document.getElementById("CruceroLi").style.backgroundColor = '#6101d1';
        document.getElementById("TransladosLi").style.backgroundColor = '#6101d1';
        document.getElementById("ActividadesLi").style.backgroundColor = '#6101d1';
        document.getElementById("ptw-container").style.display = 'none'
    }
}

$(document).ready(function () {

    $('#contactoBoton').mouseover(function () {
        document.getElementById("auricularInfo").style.display = 'block'
        document.getElementById("whatsappInfo").style.display = 'block'
    });
    $('#contactoBoton').mouseleave(function () {
        document.getElementById("auricularInfo").style.display = 'none'
        document.getElementById("whatsappInfo").style.display = 'none'
    });



    var stringHtml = '<script type="text/javascript" src="https://widgets.priceres.co/gruposco/jsonpBooker/startWidget?container=ptw-container&UseConfigs=true&CurrentSection=3&CurrentEngine=3&ShowProducts=false&EngineConfigs[0].Engine=3&EngineConfigs[1].Engine=8&SectionConfigs[0].SectionTab=3&SectionConfigs[0].DefaultEngine=3&IsHorizontal=true"></script>'; //Vuelos
    $('#ptw-container').append(stringHtml)

    var OSName = "Desconocido";
    if (navigator.appVersion.indexOf("Win") != -1) OSName = "Windows";
    if (navigator.appVersion.indexOf("iPhone") != -1) OSName = "iPhone";
    if (navigator.appVersion.indexOf("X11") != -1) OSName = "UNIX";
    if (navigator.appVersion.indexOf("Linux") != -1) OSName = "Linux";
    if (navigator.appVersion.indexOf("Android") != -1) OSName = "Android";
    if (OSName == "Android" || OSName == "iPhone") {
        //window.location.href = "https://m.grupos.co";
        //window.location.href = "https://viajes.grupos.co/";

    }

    $("#cerrar").click(function () {
        location.reload();
    })

    //$("#BtnAceptarRegistro").click(function () {
    //    $('#modalRegistro').modal('toggle');
    //})


    /*Campos Grupos*/
    //$("#arrivedDate").datepicker({
    //    dateFormat: 'yy-mm-dd',
    //    changeMonth: true,
    //    changeYear: true,
    //    minDate: new Date(),
    //    onSelect: function () {
    //        $('#returnDate').datepicker('option', 'minDate', $("#arrivedDate").datepicker("getDate"));
    //    }
    //}).datepicker("setDate", new Date());

    //$("#returnDate").datepicker({
    //    dateFormat: 'yy-mm-dd',
    //    changeMonth: true,
    //    changeYear: true
    //}).datepicker("setDate", new Date('yy-mm-dd'));

    $('#source').change(function () {
        var input = $('#source');
        var valor = input.val();
        if (valor) {
            $('span[data-valmsg-for="source"]').html('');
        }
        else {
            $('span[data-valmsg-for="source"]').html('Campo obligatorio');
            return false;
        }
    });

    //$('#arrivedDate').change(function () {

    //    var input = $('#arrivedDate');
    //    var valor = input.val();
    //    if (valor) {
    //        $('span[data-valmsg-for="arrivedDate"]').html('');
    //    }
    //    else {
    //        $('span[data-valmsg-for="arrivedDate"]').html('Campo obligatorio');
    //        return false;
    //    }
    //});

    //$('#arrivedDayTime').change(function () {

    //    var input = $('#arrivedDayTime');
    //    var valor = input.val();
    //    if (valor) {
    //        $('span[data-valmsg-for="arrivedDayTime"]').html('');
    //    }
    //    else {
    //        $('span[data-valmsg-for="arrivedDayTime"]').html('Campo obligatorio');
    //        return false;
    //    }
    //});

    $('#destination').change(function () {

        var input = $('#destination');
        var valor = input.val();
        if (valor) {
            $('span[data-valmsg-for="destination"]').html('');
        }
        else {
            $('span[data-valmsg-for="destination"]').html('Campo obligatorio');
            return false;
        }
    });

    //$('#returnDate').change(function () {

    //    var input = $('#returnDate');
    //    var valor = input.val();
    //    if (valor) {
    //        $('span[data-valmsg-for="returnDate"]').html('');
    //    }
    //    else {
    //        $('span[data-valmsg-for="returnDate"]').html('Campo obligatorio');
    //        return false;
    //    }
    //});

    //$('#returnDayTime').change(function () {

    //    var input = $('#returnDayTime');
    //    var valor = input.val();
    //    if (valor) {
    //        $('span[data-valmsg-for="returnDayTime"]').html('');
    //    }
    //    else {
    //        $('span[data-valmsg-for="returnDayTime"]').html('Campo obligatorio');
    //        return false;
    //    }
    //});

    $('#groupType').change(function () {

        var input = $('#groupType');
        var valor = input.val();
        if (valor) {
            $('span[data-valmsg-for="groupType"]').html('');
        }
        else {
            $('span[data-valmsg-for="groupType"]').html('Campo obligatorio');
            return false;
        }
    });

    $('#adultsNumber').change(function () {

        var input = $('#adultsNumber');
        var valor = input.val();
        if (valor) {
            $('span[data-valmsg-for="adultsNumber"]').html('');
        }
        else {
            $('span[data-valmsg-for="adultsNumber"]').html('Campo obligatorio');
            return false;
        }
    });

    $('#fullName').change(function () {

        var input = $('#fullName');
        var valor = input.val();
        if (valor) {
            $('span[data-valmsg-for="fullName"]').html('');
        }
        else {
            $('span[data-valmsg-for="fullName"]').html('Campo obligatorio');
            return false;
        }
    });

    $('#Email').change(function () {
        var input = $('#Email');
        var valor = input.val();
        if (valor) {
            $('span[data-valmsg-for="Email"]').html('');
            var emailValid = isValidEmailAddress(valor);
            if (emailValid) {
                $('span[data-valmsg-for="Email"]').html('');
            }
            else {
                $('span[data-valmsg-for="Email"]').html('Email no válido');
            }
        }
        else {
            $('span[data-valmsg-for="Email"]').html('Campo obligatorio');
            return false;
        }
    });

    $('#phoneNumber').change(function () {

        var input = $('#phoneNumber');
        var valor = input.val();
        if (valor) {
            $('span[data-valmsg-for="phoneNumber"]').html('');
        }
        else {
            $('span[data-valmsg-for="phoneNumber"]').html('Campo obligatorio');
            return false;
        }
    });

    $('#isAgency').change(function () {
        var input = $('#isAgency');
        var valor = input.val();
        if (valor) {
            document.getElementById("agency").innerHTML = '';

            document.getElementById("isNoAgency").checked = false;
        }
    });

    $('#isNoAgency').change(function () {
        var input = $('#isAgency');
        var valor = input.val();
        if (valor) {
            document.getElementById("agency").innerHTML = '';
            document.getElementById("isAgency").checked = false;

        }
    });

    $('#isNoAgency').click(function () {
        document.getElementById("isAgency").checked = false;
    });

    $('#btnEnviarForm').click(function () {

        var formValid = true;
        var origen = $('#source').val();
        var destino = $('#destination').val();
        var fechaIda = $('#arrivedDate').val();
        var fechaRegreso = $('#returnDate').val();
        var jornadaIda = $('#arrivedDayTime').val();
        var jornadaRegreso = $('#returnDayTime').val();
        var grupo = $('#groupType').val();
        var adultos = $('#adultsNumber').val();
        var ninos = $('#childsNumber').val();
        var esagencia = $('#isAgency').prop('checked');
        var noesagencia = $('#isNoAgency').prop('checked');
        var observaciones = $('#Observations').val();
        var nombres = $('#fullName').val();
        var email = $('#Email').val();
        var telefono = $('#phoneNumber').val();
        var emailDestination = $('#emailDestination').val();

        if (origen == '') {
            $('span[data-valmsg-for="source"]').html('Campo obligatorio');
            return false;
            formValid = false;
        }
        else if (destino == '') {
            $('span[data-valmsg-for="destination"]').html('Campo obligatorio');
            return false;
            formValid = false;
        }
        else if (fechaIda == '') {
            $('span[data-valmsg-for="arrivedDate"]').html('Campo obligatorio');
            return false;
            formValid = false;
        }
        else if (fechaRegreso == '') {
            $('span[data-valmsg-for="returnDate"]').html('Campo obligatorio');
            return false;
            formValid = false;
        }
        else if (jornadaIda == '') {
            $('span[data-valmsg-for="arrivedDayTime"]').html('Campo obligatorio');
            return false;
            formValid = false;
        }
        else if (jornadaRegreso == '') {
            $('span[data-valmsg-for="returnDayTime"]').html('Campo obligatorio');
            return false;
            formValid = false;
        }
        else if (grupo == '') {
            $('span[data-valmsg-for="groupType"]').html('Campo obligatorio');
            return false;
            formValid = false;
        }
        else if (adultos == '') {
            $('span[data-valmsg-for="adultsNumber"]').html('Campo obligatorio');
            return false;
            formValid = false;
        }
        else if (nombres == '') {
            $('span[data-valmsg-for="fullName"]').html('Campo obligatorio');
            return false;
            formValid = false;
        }
        else if (email == '') {
            $('span[data-valmsg-for="Email"]').html('Campo obligatorio');
            return false;
            formValid = false;
        }
        else if (telefono == '') {
            $('span[data-valmsg-for="phoneNumber"]').html('Campo obligatorio');
            return false;
            formValid = false;
        }
        else if (esagencia == false && noesagencia == false) {
            document.getElementById("agency").innerHTML = 'Seleccione una opción';
            formValid = false;
        }

        if (formValid) {

            //debugger;
            $.ajax({
                url: '/Home/Index',
                type: 'post',
                data: {
                    'source': origen,
                    'destination': destino,
                    'arrivedDate': fechaIda,
                    'returnDate': fechaRegreso,
                    'arrivedDayTime': jornadaIda,
                    'returnDayTime': jornadaRegreso,
                    'childsNumber': ninos,
                    'adultsNumber': adultos,
                    'groupType': grupo,
                    'isAgency': esagencia,
                    'isNoAgency': noesagencia,
                    'fullName': nombres,
                    'Email': email,
                    'Observations': observaciones,
                    'phoneNumber': telefono,
                    'emailDestination': emailDestination
                },
                success: function (data) {
                    document.getElementById("consecutivo").innerHTML = data['Consecutivo'];
                    console.log(data['Consecutivo'])
                    $('#exampleModal').modal('show');
                }
            });
        }
    });
    /*Campos Corporativo*/

    //$("#arrivedDateCorp").datepicker({
    //    dateFormat: 'yy-mm-dd',
    //    changeMonth: true,
    //    changeYear: true,
    //    minDate: new Date(),
    //    onSelect: function () {
    //        $('#returnDateCorp').datepicker('option', 'minDate', $("#arrivedDateCorp").datepicker("getDate"));
    //    }
    //}).datepicker("setDate", new Date());

    //$("#returnDateCorp").datepicker({
    //    dateFormat: 'yy-mm-dd',
    //    changeMonth: true,
    //    changeYear: true
    //}).datepicker("setDate", new Date('yy-mm-dd'));

    $('#sourceCorp').change(function () {
        var input = $('#sourceCorp');
        var valor = input.val();
        if (valor) {
            $('span[data-valmsg-for="source"]').html('');
        }
        else {
            $('span[data-valmsg-for="source"]').html('Campo obligatorio');
            return false;
        }
    });

    $('#arrivedDateCorp').change(function () {

        var input = $('#arrivedDateCorp');
        var valor = input.val();
        if (valor) {
            $('span[data-valmsg-for="arrivedDate"]').html('');
        }
        else {
            $('span[data-valmsg-for="arrivedDate"]').html('Campo obligatorio');
            return false;
        }
    });

    $('#arrivedDayTimeCorp').change(function () {

        var input = $('#arrivedDayTimeCorp');
        var valor = input.val();
        if (valor) {
            $('span[data-valmsg-for="arrivedDayTime"]').html('');
        }
        else {
            $('span[data-valmsg-for="arrivedDayTime"]').html('Campo obligatorio');
            return false;
        }
    });

    $('#destinationCorp').change(function () {
        var input = $('#destinationCorp');
        var valor = input.val();
        if (valor) {
            $('span[data-valmsg-for="destination"]').html('');
        }
        else {
            $('span[data-valmsg-for="destination"]').html('Campo obligatorio');
            return false;
        }
    });

    $('#returnDateCorp').change(function () {
        var input = $('#returnDateCorp');
        var valor = input.val();
        if (valor) {
            $('span[data-valmsg-for="returnDate"]').html('');
        }
        else {
            $('span[data-valmsg-for="returnDate"]').html('Campo obligatorio');
            return false;
        }
    });

    $('#returnDayTimeCorp').change(function () {
        var input = $('#returnDayTimeCorp');
        var valor = input.val();
        if (valor) {
            $('span[data-valmsg-for="returnDayTime"]').html('');
        }
        else {
            $('span[data-valmsg-for="returnDayTime"]').html('Campo obligatorio');
            return false;
        }
    });

    $('#groupTypeCorp').change(function () {
        var input = $('#groupTypeCorp');
        var valor = input.val();
        if (valor) {
            $('span[data-valmsg-for="groupType"]').html('');
        }
        else {
            $('span[data-valmsg-for="groupType"]').html('Campo obligatorio');
            return false;
        }
    });

    $('#adultsNumberCorp').change(function () {
        var input = $('#adultsNumberCorp');
        var valor = input.val();
        if (valor) {
            $('span[data-valmsg-for="adultsNumber"]').html('');
        }
        else {
            $('span[data-valmsg-for="adultsNumber"]').html('Campo obligatorio');
            return false;
        }
    });

    $('#fullNameCorp').change(function () {
        var input = $('#fullNameCorp');
        var valor = input.val();
        if (valor) {
            $('span[data-valmsg-for="fullName"]').html('');
        }
        else {
            $('span[data-valmsg-for="fullName"]').html('Campo obligatorio');
            return false;
        }
    });

    $('#EmailCorp').change(function () {
        var input = $('#EmailCorp');
        var valor = input.val();
        if (valor) {
            $('span[data-valmsg-for="Email"]').html('');
            var emailValid = isValidEmailAddress(valor);
            if (emailValid) {
                $('span[data-valmsg-for="Email"]').html('');
            }
            else {
                $('span[data-valmsg-for="Email"]').html('Email no válido');
            }
        }
        else {
            $('span[data-valmsg-for="Email"]').html('Campo obligatorio');
            return false;
        }
    });

    $('#phoneNumberCorp').change(function () {
        var input = $('#phoneNumberCorp');
        var valor = input.val();
        if (valor) {
            $('span[data-valmsg-for="phoneNumber"]').html('');
        }
        else {
            $('span[data-valmsg-for="phoneNumber"]').html('Campo obligatorio');
            return false;
        }
    });

    $('#isAgencyCorp').change(function () {
        var input = $('#isAgencyCorp');
        var valor = input.val();
        if (valor) {
            document.getElementById("agencyCorp").innerHTML = '';
            document.getElementById("isNoAgencyCorp").checked = false;
        }
    });

    $('#isNoAgencyCorp').change(function () {
        var input = $('#isAgencyCorp');
        var valor = input.val();
        if (valor) {
            document.getElementById("agencyCorp").innerHTML = '';
            document.getElementById("isAgencyCorp").checked = false;
        }
    });

    $('#isNoAgencyCorp').click(function () {
        document.getElementById("isAgencyCorp").checked = false;
    });

    $('#btnEnviarFormCorp').click(function () {
        var formValid = true;
        var origen = $('#sourceCorp').val();
        var destino = $('#destinationCorp').val();
        var fechaIda = $('#arrivedDateCorp').val();
        var fechaRegreso = $('#returnDateCorp').val();
        var jornadaIda = $('#arrivedDayTimeCorp').val();
        var jornadaRegreso = $('#returnDayTimeCorp').val();
        var grupo = $('#groupTypeCorp').val();
        var adultos = $('#adultsNumberCorp').val();
        var ninos = $('#childsNumberCorp').val();
        var esagencia = $('#isAgencyCorp').prop('checked');
        var noesagencia = $('#isNoAgencyCorp').prop('checked');
        var observaciones = $('#ObservationsCorp').val();
        var nombres = $('#fullNameCorp').val();
        var email = $('#EmailCorp').val();
        var telefono = $('#phoneNumberCorp').val();
        var emailDestination = $('#emailDestinationCorp').val();

        if (origen == '') {
            $('span[data-valmsg-for="source"]').html('Campo obligatorio');
            return false;
            formValid = false;
        }
        else if (destino == '') {
            $('span[data-valmsg-for="destination"]').html('Campo obligatorio');
            return false;
            formValid = false;
        }
        else if (fechaIda == '') {
            $('span[data-valmsg-for="arrivedDate"]').html('Campo obligatorio');
            return false;
            formValid = false;
        }
        else if (fechaRegreso == '') {
            $('span[data-valmsg-for="returnDate"]').html('Campo obligatorio');
            return false;
            formValid = false;
        }
        else if (jornadaIda == '') {
            $('span[data-valmsg-for="arrivedDayTime"]').html('Campo obligatorio');
            return false;
            formValid = false;
        }
        else if (jornadaRegreso == '') {
            $('span[data-valmsg-for="returnDayTime"]').html('Campo obligatorio');
            return false;
            formValid = false;
        }
        else if (grupo == '') {
            $('span[data-valmsg-for="groupType"]').html('Campo obligatorio');
            return false;
            formValid = false;
        }
        else if (adultos == '') {
            $('span[data-valmsg-for="adultsNumber"]').html('Campo obligatorio');
            return false;
            formValid = false;
        }
        else if (nombres == '') {
            $('span[data-valmsg-for="fullName"]').html('Campo obligatorio');
            return false;
            formValid = false;
        }
        else if (email == '') {
            $('span[data-valmsg-for="Email"]').html('Campo obligatorio');
            return false;
            formValid = false;
        }
        else if (telefono == '') {
            $('span[data-valmsg-for="phoneNumber"]').html('Campo obligatorio');
            return false;
            formValid = false;
        }
        else if (esagencia == false && noesagencia == false) {
            document.getElementById("agency").innerHTML = 'Seleccione una opción';
            formValid = false;
        }

        if (formValid) {

            //debugger;
            $.ajax({
                url: '/Home/Index',
                type: 'post',
                data: {
                    'source': origen,
                    'destination': destino,
                    'arrivedDate': fechaIda,
                    'returnDate': fechaRegreso,
                    'arrivedDayTime': jornadaIda,
                    'returnDayTime': jornadaRegreso,
                    'childsNumber': ninos,
                    'adultsNumber': adultos,
                    'groupType': grupo,
                    'isAgency': esagencia,
                    'isNoAgency': noesagencia,
                    'fullName': nombres,
                    'Email': email,
                    'Observations': observaciones,
                    'phoneNumber': telefono,
                    'emailDestination': emailDestination
                },
                success: function (data) {
                    document.getElementById("consecutivo").innerHTML = data['Consecutivo'];
                    console.log(data['Consecutivo'])
                    $('#exampleModal').modal('show');
                }
            });
        }
    });

    /*Campos Registrate*/
    $('#Correo').change(function () {
        var input = $('#Correo');
        var valor = input.val();
        if (valor) {
            $('#correo').html('');
            var emailValid = isValidEmailAddress(valor);
            if (emailValid) {
                $('#correo').html('');
            }
            else {
                $('#correo').html('Email no válido');
            }
        }
        else {
            $('#correo').html('Campo obligatorio');
            return false;
        }
    });

    $('#Nombres').change(function () {
        var input = $('#Nombres');
        var valor = input.val();
        if (valor) {
            $('#nombres').html('');
        }
        else {
            $('#nombres').html('Campo obligatorio');
            return false;
        }
    });

    $('#Terminos').change(function () {
        var input = $('#Terminos');
        var valor = input.val();
        if (valor) {
            $('#terminos').html('');
        }
        else {
            $('#terminos').html('Debe aceptar los términos y condiciones');
            return false;
        }
    });

    $('#btnRegistrate').click(function () {
        limpiarRegistro();
        limpiarRegistroInputs();
    });
    function limpiarRegistro() {
        $('#agencyNameError').css("display", "block");
        $('#agencyNameError').html('');
        $('#contactTypeError').css("display", "block");
        $('#contactTypeError').html('');
        $('#contactNameError').css("display", "block");
        $('#contactNameError').html('');
        $('#cityNameError').css("display", "block");
        $('#cityNameError').html('');
        $('#phoneNumberError').css("display", "block");
        $('#phoneNumberError').html('');
        $('#emailError').css("display", "block");
        $('#emailError').html('');
        $('#terminosError').css("display", "block");
        $('#terminosError').html('');
        $('#passwordError').css("display", "block");
        $('#passwordError').html('');
    }
    function limpiarRegistroInputs() {
        $('#agencyName').val('');
        $('#contactName').val('');
        $('#cityName').val('');
        $('#phoneNumber').val('');
        $('#emailAddress').val('');
        $('#passwordRegister').val('');
        $('#terminos').prop('checked', false);
    }
    function limpiarLoginInputs() {
        $('#userName').val('');
        $('#password').val('');
        $('#userNameError').val('');
        $('#passwordErrorLogin').val('');
        $('#userNameError').css("display", "block");
        $('#passwordErrorLogin').css("display", "block");
    }
    $('#BtnAceptarRegistro').click(function () {
        var formValid = false;
        var documentType = $('#documentType').val();
        var agencyName = $('#agencyName').val();
        var contactType = $('#contactType').val();
        var contactName = $('#contactName').val();
        var cityName = $('#cityName').val();
        var phoneNumber = $('#phoneNumber').val();
        var emailAddress = $('#emailAddress').val();
        var password = $('#passwordRegister').val();
        var terminos = $('#terminos').prop('checked');



        if (documentType == '') {
            $('#documentTypeError').html('Campo obligatorio');
            $('#documentTypeError').css("display", "block");
            formValid = false;
        }
        else {
            $('#documentTypeError').html('');
            $('#documentTypeError').css("display", "none");
            formValid = true;
        }

        if (agencyName == '') {
            $('#agencyNameError').html('Campo obligatorio');
            $('#agencyNameError').css("display", "block");
            formValid = false;
        }
        else {
            $('#agencyNameError').html('');
            $('#agencyNameError').css("display", "none");
            formValid = true;
        }

        if (contactType == '') {
            $('#contactTypeError').html('Campo obligatorio');
            $('#contactTypeError').css("display", "block");
            formValid = false;
        }
        else {
            $('#contactTypeError').html('');
            $('#contactTypeError').css("display", "none");
            formValid = true;
        }

        if (contactName == '') {
            $('#contactNameError').html('Campo obligatorio');
            $('#contactNameError').css("display", "block");
            formValid = false;
        }
        else {
            $('#contactNameError').html('');
            $('#contactNameError').css("display", "none");
            formValid = true;
        }

        if (cityName == '') {
            $('#cityNameError').html('Campo obligatorio');
            $('#cityNameError').css("display", "block");
            formValid = false;
        }
        else {
            $('#cityNameError').html('');
            $('#cityNameError').css("display", "none");
            formValid = true;
        }

        if (phoneNumber == '') {
            $('#phoneNumberError').html('Campo obligatorio');
            $('#phoneNumberError').css("display", "block");
            formValid = false;
        }
        else {
            $('#phoneNumberError').html('');
            $('#phoneNumberError').css("display", "none");
            formValid = true;
        }

        if (emailAddress != '') {
            if (isValidEmailAddress(emailAddress)) {
                $('#emailError').html('');
                $('#emailError').css("display", "none");
                formValid = true;
            }
            else {
                $('#emailError').html('Email no válido');
                formValid = false;
            }
        }
        else {
            $('#emailError').html('Campo obligatorio');
            $('#emailError').css("display", "block");
            formValid = false;
        }

        if (password == '') {
            $('#passwordError').html('Campo obligatorio');
            $('#passwordError').css("display", "block");
            formValid = false;
        }
        else {
            $('#passwordError').html('');
            $('#passwordError').css("display", "none");
            formValid = true;
        }

        if (terminos) {
            $('#terminosError').html('');
            $('#terminosError').css("display", "none");
            formValid = true;
        }
        else {
            $('#terminosError').html('Debe aceptar los términos.');
            $('#terminosError').css("display", "block");
            formValid = false;
        }


        if (formValid) {
            $.ajax({
                url: '/Grupos/Registrate',
                type: 'post',
                data: {
                    documentType: documentType,
                    agencyName: agencyName,
                    contactType: contactType,
                    contactName: contactName,
                    cityName: cityName,
                    phoneNumber: phoneNumber,
                    emailAddress: emailAddress,
                    password: password,
                    terminos: terminos
                },
                success: function () {
                    limpiarRegistro();
                    limpiarRegistroInputs();
                    alert('Gracias por su registro!!!.');

                },
                error: function () {
                    alert('Ocurrió un error al registrar, intentelo más tarde.');
                }
            });
        }
    });

    $('#btnLogin').click(function () {
        var formValid = false;
        var userName = $('#userName').val();
        var password = $('#password').val();
        if (userName == '') {
            $('#userNameError').html('Campo obligatorio');
            $('#userNameError').css("display", "block");
            formValid = false;
        }
        else {
            $('#userNameError').html('');
            $('#userNameError').css("display", "none");
            formValid = true;
        }
        if (password == '') {
            $('#passwordError').html('Campo obligatorio');
            $('#passwordError').css("display", "block");
            formValid = false;
        }
        else {
            $('#passwordError').html('');
            $('#passwordError').css("display", "none");
            formValid = true;
        }

        if (formValid) {
            $.ajax({
                url: '/Grupos/Login',
                type: 'post',
                dataType: 'json',
                crossDomain: true,
                data: {
                    userName: userName,
                    password: password
                },
                success: function (data) {
                    var token = data["jwt"];
                    if (token != null && token != undefined && token != '') {
                        window.location.href = data["Url"];
                    }
                    else {
                        alert("Acceso no autorizado")
                    }
                    
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert('Usuario o contraseña incorrecto.');
                }
            });
        }
    });

    function isValidEmailAddress(emailAddress) {
        var pattern = new RegExp(/^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/);
        return pattern.test(emailAddress);
    }
});

$(document).ready(main);

var contador = 1;

function main() {
    $('.menu_bar').click(function () {
        // $('nav').toggle();

        if (contador == 1) {
            $('nav').animate({
                left: '0'
            });
            contador = 0;
        } else {
            contador = 1;
            $('nav').animate({
                left: '-100%'
            });
        }

    });

};
