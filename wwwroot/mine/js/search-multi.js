$(document).ready(function () {
    //code dans nouveau courrier
    $('#destinataires_modif').hide();
    function emailValide(email) {
        var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
        console.log("Email test ==> " + emailReg.test(email));
        return (email != "" && emailReg.test(email));
    }
    function htmlAjoutDest(email) {
        let html = "<tr class=\"ligne_dest\"><td>" + email + "</td>"
            + "<td><btn class=\"btn btn-danger btn_supp_dest\">Supprimer</btn></td>"
            + "</tr >";
        return html;
    }
    function concatWithSeparator(array, separator) {
        let string = "";
        for (let i = 0; i < array.length; i++) {
            string += array[i] + separator;
        }
        return string;
    }

    $('#btn_destinataires_modif').click(function () {
        if ($('#destinataires_modif').is(":hidden"))
            $("#destinataires_modif").toggle("slide");
        else
            $('#destinataires_modif').hide("slow");
    });
    $("#btn_ajout_dest").click(function () {
        let contenu = $("#email_dest").val();
        if (emailValide(contenu)) {
            console.log("Email valide")
            let stringDest = $('#destinataires').val();
            let destinataires = stringDest.split(";");
            if (destinataires.includes(contenu)) {
                alert("Adresse email ecrit 2 fois");
            }
            else {
                let valeur = stringDest + contenu + ";";
                $('#destinataires').val(valeur);
                $('#liste_dest').append(htmlAjoutDest(contenu));
            }
        }
        else { alert("Adresse email non valide"); }
    });

    $(document).on('click', '.ligne_dest', function () {
        $(this).find('.btn_supp_dest').click(function () {
            let destinataires = $('#destinataires').val().split(";");
            let iLigne = $(this).parent().parent()[0].sectionRowIndex;
            alert("Numero de ligne " + iLigne);
            destinataires.splice(iLigne - 1, 1);
            destinataires.splice(destinataires.length - 1);    //remove the empty string at last
            let stringDest = concatWithSeparator(destinataires, ";");
            console.log(destinataires);
            $('#destinataires').val(stringDest);
            $(this).parent().parent().remove();
        });
    });
    //fin code dans nouveau courrier

    $('#search_multi').hide();
    $('.courrier-card').hover(function () {
        $(this).addClass('border-left-primary');
        $(this).mouseleave(function () {
            $(this).removeClass('border-left-primary');
        });
    });
    $('.btn_search_multi').click(function () {
        if ($('#search_multi').is(":hidden"))
            $("#search_multi").toggle("slide");
        else
            $('#search_multi').hide("slow");
    });

});
