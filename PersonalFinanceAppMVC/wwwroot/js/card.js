function highlightText() {
    var searchText = document.getElementById("searchText").value;
    var cardProperties = document.querySelectorAll(".card *");

    cardProperties.forEach(function (property) {
        property.innerHTML = property.textContent;
    });

    cardProperties.forEach(function (property) {
        var regex = new RegExp(searchText, "gi");
        property.innerHTML = property.textContent.replace(regex, function (match) {
            return "<span class='highlight'>" + match + "</span>";
        });
    });
}
document.getElementById("searchText").addEventListener("input", highlightText);
<script>
        // JavaScript code for modal popup
    var modal = document.getElementById("myModal");
    var span = document.getElementsByClassName("close")[0];

    var cards = document.querySelectorAll(".card");
    cards.forEach(function(card) {
        card.addEventListener("click", function () {
            modal.style.display = "block";
        });
        });

    span.onclick = function() {
        modal.style.display = "none";
        };

    window.onclick = function(event) {
            if (event.target == modal) {
        modal.style.display = "none";
            }
        };
</script>