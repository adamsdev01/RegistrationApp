$(document).ready(function () {
    var currentTab = 0; // Current tab is set to be the first tab (0)
    showTab(currentTab); // Display the current tab

    function showTab(n) {
        // This function will display the specified tab of the form...
        var x = $(".tab");
        x.hide();
        $(x[n]).show();

    }
    $("#nextBtn").click(function () {
        // Clear previous results
        $("#searchResults").empty();
        $("#noResults").hide();
        $("#ajaxError").hide();
        // Get search criteria
        var firstName = $("#firstName").val();
        var lastName = $("#lastName").val();
        var accountNumber = $("#accountNumber").val();

        // AJAX call
        $.ajax({
            url: "/Search/PerformSearch", // Replace with your controller and action
            type: "POST",
            data: {
                firstName: firstName,
                lastName: lastName,
                accountNumber: accountNumber
            },
            dataType: "html",
            success: function (data) {
                $("#searchResults").html(data);
                currentTab = currentTab + 1;
                showTab(currentTab);
            },
            error: function (error) {
                // Error handling
                $("#ajaxError").show();
                $("#ajaxError").html("<p>There was an error processing your request.</p>");
                console.error("AJAX error:", error);
                currentTab = currentTab + 1;
                showTab(currentTab);
            }
        });
    });
    $("#prevBtn").click(function () {
        currentTab = currentTab - 1;
        showTab(currentTab);
    });
});
