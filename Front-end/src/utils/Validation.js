export const textIsValid = (text) => {
    if (text.trim().length > 0) {
        return true;
    }
    return false;
};

export const emailIsValid = (email) => {
    const validEmailRegex = RegExp(/^[\w-.]+@([\w-]+\.)+[\w-]{2,4}$/);

    if (validEmailRegex.test(email)) {
        return true;
    }
    return false;
};

export const passwordIsValid = (password) => {
    if (password.trim().length > 4) {
        return true;
    }
    return false;
};

export const phoneNumberIsValid = (phoneNumber) => {
    const validPhoneNumberRegex = RegExp(/^[0-9]+$/);

    if (validPhoneNumberRegex.test(phoneNumber)) {
        return true;
    }
    return false;
};