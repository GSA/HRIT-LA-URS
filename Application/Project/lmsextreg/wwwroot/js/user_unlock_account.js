function unlockUserAccount(userId) {
    console.log(`[user_unlock.js][unlockUserAccount] => (userId): ${userId}`)

    const userAccount = {
        id: userId
    };

    console.log("`[user_unlock.js][unlockUserAccount] => (userAccount): ", userAccount);

    $.ajax({
        type: "POST",
        accepts: "application/json",
        url: "/api/user/account/lock",
        contentType: "application/json",
        data: JSON.stringify(userAccount),
        error: function (jqXHR, testStatus, errorThrown) {
            console.log("[user_unlock.js][unlockUserAccount][error] => (jqXHR): ", jqXHR);
            console.log("[user_unlock.js][unlockUserAccount][error] => (testStatus): ", testStatus);
            console.log("[user_unlock.js][unlockUserAccount][error] => (errorThrown): ", errorThrown);
        },
        success: function (result) {
            console.log("[user_unlock.js][unlockUserAccount][success] => (result): ", result);
            //console.log("[user_unlock.js][unlockUserAccount][success] =>");
            isUserAccountLocked(userId);
        }
    });
}

function isUserAccountLocked(userId) {
    console.log(`[user_unlock.js][isUserAccountLocked] => (userId): ${userId}`);

    $.ajax({
        type: "GET",
        url: "/api/user/account/lock",
        data: {
            userId: userId
        },
        cache: false,
        success: function (data) {
            //console.log(`[user_unlock.js][isUserAccountLocked][success] => (data): ${data}`);
            console.log(`[user_unlock.js][isUserAccountLocked][success] => (data): ${data}`);
            processResponse(data);

         }
    });
}

function processResponse(responseData) {

    let userIsLockedOut = document.getElementById("userIsLockedOut");
    if (userIsLockedOut) {
        userIsLockedOut.innerText = responseData;
    }
    processPopup();
}

function processPopup() {
    let userAccountModalTitle = document.getElementById("userAccountModalTitle");
    if (userAccountModalTitle) {
        userAccountModalTitle.innerText = "Account Unlocked";
    }
    if (userAccountModelBody) {
        userAccountModelBody.innerText = "This user's account has been unlocked.";
    }
    if (userAccountModalButton) {
        userAccountModalButton.click();
    }
}