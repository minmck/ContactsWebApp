import { useState } from "react";
import { textIsValid, phoneNumberIsValid, emailIsValid } from "../../utils/Validation";
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

    const submitHandler = (event) => {
        event.preventDefault();
        if (formIsValid()) {
            console.log('Valid');
        } else {
            console.log('Invalid');
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
                {/* <div> */}
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
                {/* </div> */}
                <div className={styles['new-contact__controls']}>
                    <button type='submit'>Add contact</button>
                </div>
            </form>
        </Card>
    );
};

export default NewContactForm;