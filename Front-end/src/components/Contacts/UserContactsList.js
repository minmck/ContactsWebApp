import axios from "axios";
import { useEffect } from "react";
import { getUserId, getToken } from "../../utils/Common";
import Card from "../UI/Card";
import OneContact from "./OneContact";
import styles from "./UserContactsList.module.css";

const UserContactsList = () => {

    const contacts = [];

    useEffect(() => {
        axios.get("http://localhost:35549/api/contacts", {
            params: {
                userId: getUserId()
            },
            headers: {
                'Authorization': 'Bearer ' + getToken()
            }
        }).then(response => {
            contacts = response.data;
        }).catch(error => {
            console.log('errors: ', error.response);
        })
    });

    // const contacts = [
    //     {
    //         id: 1,
    //         fullName: 'Vardenis Pavardenis',
    //         phoneNumber: '1234567890',
    //         email: 'email@email.com'
    //     },
    //     {
    //         id: 2,
    //         fullName: 'Jonas Jonaitis',
    //         phoneNumber: '0987651',
    //         email: 'mail@mail.lt'
    //     },
    //     {
    //         id: 3,
    //         fullName: 'Petras Petraitis',
    //         phoneNumber: '55511132',
    //         email: 'petras@mail.lt'
    //     }
    // ]

    return (
        <Card className={styles['user-contacts']}>
            <p className={styles['user-contacts__title']}>My contacts:</p>
            {contacts.map(function (contact) {
                return <OneContact contact={contact} key={contact.id} />
            })}
        </Card>
    );
};

export default UserContactsList;