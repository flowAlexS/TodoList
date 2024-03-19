import { SetCookie } from "./CookieHandler";

const PostAccount = async (acc, url) => {
    try {
        const response = await fetch(url, {
            method: "POST",
            headers: {
                "Accept": "*/*",
                "Content-Type": "application/json"
            },
            body: JSON.stringify(acc),
        });

        if (!response.ok) {
            throw Error('Something went wrong');
        }

        const data = await response.json();
        SetCookie(data);
        return true;
    } catch (error) {
        return false;
    }
};

export default PostAccount;