import axios from "axios";
import { useState } from "react";
import { textIsValid, phoneNumberIsValid, emailIsValid } from "../../utils/Validation";
import { getUserId, getToken } from "../../utils/Common";
import Card from "../UI/Card";
import UserInput from "../UI/UserInput";
import styles from "./NewContactForm.module.css";

const NewContactForm = () => {
    const [fullName, setFullName] = useState('');
    const [phoneNumber, setPhoneNumber] = useState('');
    const [email, setEmail] = useState('');
    const [fullNameInvalid, setFullNameInvalid] = useState(false);
    const [phoneNumberInvalid, setPhoneNumberInvalid] = useState(false);
    const [emailInvalid, setEmailInvalid] = useState(false);
    const [refresh, setRefresh] = useState();

    const submitHandler = (event) => {
        const data = {
            fullName: fullName,
            phoneNumber: phoneNumber,
            email: email
        }

        if (formIsValid()) {
            axios.post("http://localhost:35549/api/users/" + getUserId() + "/contacts", data, {
                headers: {
                    'Authorization': 'Bearer ' + getToken()
                }
            }).then(response => {
                if (response.status === 201) {
                }
                setRefresh();
                console.log('response: ', response);
            }).catch(error => {
                console.log('errors: ', error.response);
            })
        } else {
            event.preventDefault();
        }
    };

    const handleFullNameChange = (value) => {
        setFullName(value);
    };

    const handlePhoneNumberChange = (value) => {
        setPhoneNumber(value);
    };

    const handleEmailChange = (value) => {
        setEmail(value);
    };

    const formIsValid = () => {
        resetStateErrors();

        let fullNameInv = false;
        let phoneNumberInv = false;
        let emailInv = false;

        if (!textIsValid(fullName)) {
            setFullNameInvalid(true);
            fullNameInv = true;
        }

        if (!phoneNumberIsValid(phoneNumber)) {
            setPhoneNumberInvalid(true);
            phoneNumberInv = true;
        }

        if (!emailIsValid(email)) {
            setEmailInvalid(true);
            emailInv = true;
        }

        if (fullNameInv || phoneNumberInv || emailInv) {
            return false;
        }
        return true;
    };

    const resetStateErrors = () => {
        setFullNameInvalid(false);
        setPhoneNumberInvalid(false);
        setEmailInvalid(false);
    };

    return (
        <Card className={styles['new-contact']}>
            <p className={styles['new-contact__title']}>Create new contact</p>
            <form onSubmit={submitHandler}>
                <UserInput
                    label='Full name:'
                    type='text'
                    value={fullName}
                    onInputChange={handleFullNameChange}
                    error={fullNameInvalid}
                    errorMessage="Full name can't be empty."
                />
                <UserInput
                    label='Phone number:'
                    type='text'
                    value={phoneNumber}
                    onInputChange={handlePhoneNumberChange}
                    error={phoneNumberInvalid}
                    errorMessage="Phone number is not valid."
                />
                <UserInput
                    label='Email address:'
                    type='text'
                    value={email}
                    onInputChange={handleEmailChange}
                    error={emailInvalid}
                    errorMessage="Email address is not valid."
                />
                <div className={styles['new-contact__controls']}>
                    <button type='submit'>Add contact</button>
                </div>
            </form>
        </Card>
    );
};

export default NewContactForm;