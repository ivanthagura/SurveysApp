import React from 'react';
import { Segment, Button, Header, Icon } from 'semantic-ui-react';
import { Link } from 'react-router-dom';

export default function NotFoundPage(){
    return (
        <Segment placeholder>
        <Header icon>
            <Icon name="search" />
            Oops - we've looked everywhere but couldn't find this.
        </Header>
        <Segment.Inline>
            <Button as={Link} to="/surveys" primary>
                Return to Surveys page
            </Button>
        </Segment.Inline>
        </Segment>
    );
}