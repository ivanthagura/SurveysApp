import React from 'react';
import { NavLink } from 'react-router-dom';
import { Button, Container, Menu } from 'semantic-ui-react';

export default function NavBar() {
    return (
        <Menu inverted fixed='top'>
            <Container>
                <Menu.Item as={NavLink} exact to='/' header>
                    <img src="/assets/logo.png" alt="logo" style={{marginRight: 15}}/>
                    Compass Surveys
                </Menu.Item>
                <Menu.Item as={NavLink} exact to='/surveys' >
                    <Button positive inverted content='Surveys' />
                </Menu.Item>
            </Container>
        </Menu>
    );
}