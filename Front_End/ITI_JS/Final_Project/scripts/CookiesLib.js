/**
 * Cookies Library
 * @author Abdelrahman Abdelhalem
 * @version 1.0
 */

/**
 * Add a persistent or session cookie
 * @param {string} name - name of the cookie.
 * @param {string} value - value of the cookie
 * @param {number} days - number of days to keep the cookie
 */
function SetCookie(name, value, days){
    let expires = "";
    if(days){   //^ For persistent cookie
        let date = new Date();
        //^ set the expiration date
        date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));    //* Convert days to milliseconds
        expires = "; expires=" + date.toUTCString();
    }
    document.cookie = name + "=" + value + expires + "; path=/";    
    //* "path=/" means that the cookie will be available on all pages
}

/**
 * Get a cookie by its name
 * @param {string} name - name of the cookie.
 * @returns Value of the cookie
 */
function GetCookie(name){
    let nameParam = name + "";
    let arrayCookies = document.cookie.split(";");
    for(let i = 0; i < arrayCookies.length; i++){
        let cookieName = arrayCookies[i].split("=")[0].trim();
        if(cookieName === nameParam){
            return arrayCookies[i].split("=")[1];
        }
    }
    return "";
}

/**
 * Delete a cookie by setting its expiration date in the past
 * @param {string} name - name of the cookie to delete
 */
function DeleteCookie(name){
    if(!HaveCookie(name)){
        return false;
    }
    else{
        let date = new Date();
        //^ set the expiration date in the past to delete the cookie
        date.setTime(date.getTime() - 10 * 24 * 60 * 60 * 1000);
        let expires = "; expires=" + date.toUTCString();
        document.cookie = name + "=;" + expires + "; path=/";
        return true;
    }
}

/**
 * Check if a cookie exists by its name
 * @param {string} name - name of the cookie
 * @returns {boolean} - true if the cookie exists, false otherwise
 */
function HaveCookie(name){
    if(GetCookie(name) !== ""){
        return true;
    }
    else{
        return false;
    }
}