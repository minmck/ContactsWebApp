import styles from "./OneContact.module.css";
import { AiOutlineMail, AiOutlinePhone } from "react-icons/ai";
import { getUserId, getToken } from "../../utils/Common";
import { FaUserCircle } from "react-icons/fa";
import { useState } from "react";
import DisableableInput from "../UI/DisableableInput";
import axios from "axios";

const OneContact = (props) => {
    const [disabled, setDisabled] = useState(true);
    const [fullName, setFullName] = useState(props.contact.fullName);
    const [phoneNumber, setPhoneNumber] = useState(props.contact.phoneNumber);
    const [email, setEmail] = useState(props.contact.email);
    const id = props.contact.id;

    const handleFullNameChange = (value) => {
        setFullName(value);
    };

    const handlePhoneNumberChange = (value) => {
        setPhoneNumber(value);
    };

    const handleEmailChange = (value) => {
        setEmail(value);
    };

    const resetUserChanges = () => {
        setFullName(props.contact.fullName);
        setPhoneNumber(props.contact.phoneNumber);
        setEmail(props.contact.email);
        disableInput();
    };

    const enableInput = () => {
        setDisabled(false);
    };

    const disableInput = () => {
        setDisabled(true);
    };

    const editOrSave = () => {
        if (disabled) {
            enableInput();
        } else {
            disableInput();
            // Send update request 
        }
    };

    const deleteOrCancel = () => {
        if (disabled) {
            axios.delete("http://localhost:35549/api/users/" + getUserId() + "/contacts/" + id, {
                headers: {
                    'Authorization': 'Bearer ' + getToken()
                }
            }).then(response => {
                if (response.status === 200) {
                    props.onRefresh();
                }
                console.log("response: ", response);
            }).catch(error => {
                console.log('errors: ', error.response);
            })
        } else {
            resetUserChanges();
            disableInput();
        }
    };

    return (
        <div className={styles['contact-info']}>
            <div className={styles.flexbox}>
                <div>
                    <div className={styles['full-name']}>
                        <DisableableInput
                            type='text'
                            className={`${styles.input} ${disabled && styles.disabled}`}
                            disabled={disabled}
                            value={fullName}
                            onInputChange={handleFullNameChange}
                        />
                    </div>
                    <div className={styles['data-field']}>
                        <AiOutlinePhone className={styles.icon} />
                        <DisableableInput
                            type='text'
                            className={`${styles.input} ${disabled && styles.disabled}`}
                            disabled={disabled}
                            value={phoneNumber}
                            onInputChange={handlePhoneNumberChange}
                        />
                    </div>
                    <div className={styles['data-field']}>
                        <AiOutlineMail className={styles.icon} />
                        <DisableableInput
                            type='text'
                            className={`${styles.input} ${disabled && styles.disabled}`}
                            disabled={disabled}
                            value={email}
                            onInputChange={handleEmailChange}
                        />
                    </div>
                </div>
                <div>
                    <FaUserCircle className={`${styles.icon} ${styles['user-icon']}`} />
                </div>
            </div>
            <div className={styles.controls}>
                <button className={styles['btn-edit']} onClick={editOrSave}>{disabled ? 'Edit' : 'Save'}</button>
                <button className={styles['btn-delete']} onClick={deleteOrCancel}>{disabled ? 'Delete' : 'Cancel'}</button>
            </div>
        </div>
    );
};

export default OneContact;