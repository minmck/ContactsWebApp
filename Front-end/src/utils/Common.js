export const setUserSession = (token, id, firstName) => {
    sessionStorage.setItem("token", token);
    sessionStorage.setItem("id", id);
    sessionStorage.setItem("firstName", firstName);
}

export const getUserId = () => {
    return sessionStorage.getItem("id") || null;
}

export const getFirstName = () => {
    return sessionStorage.getItem("firstName") || null;
}

export const getToken = () => {
    return sessionStorage.getItem("token") || null;
}