const cookieName = 'Auth';

const SetCookie = (value) => {
    const cookieData = JSON.stringify(value);
    document.cookie = `${encodeURIComponent(cookieName)}=${encodeURIComponent(cookieData)}`;
};

const GetCookie = () => {
    const decodedCookie = decodeURIComponent(document.cookie);
    const cookieArray = decodedCookie.split(';');

    for (let i = 0; i < cookieArray.length; i++) {
        let cookie = cookieArray[i].trim();
        if (cookie.indexOf(cookieName + '=') === 0) {
            return JSON.parse(cookie.substring(cookieName.length + 1)); // Parse the JSON string
        }
    }

    return null;
};

export { SetCookie, GetCookie };