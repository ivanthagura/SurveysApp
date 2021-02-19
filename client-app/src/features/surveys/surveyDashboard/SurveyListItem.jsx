import React from 'react';
import { Link } from 'react-router-dom';
import { Item, Segment, Button } from 'semantic-ui-react';

export default function SurveyListItem({survey}) {
    return (
        <Segment.Group>
            <Segment>
                <Item.Group>
                    <Item>
                        <Item.Image size='tiny' circular src='/assets/survey.png' />
                        <Item.Content>
                            <Item.Header content={survey.name} />
                            <Item.Description>
                                Click on View to start this survey
                            </Item.Description>
                        </Item.Content>
                    </Item>
                </Item.Group>
            </Segment>
            <Segment clearing>
                <Button as={Link} to={`/surveys/${survey.id}`} color='teal' floated='right' content='View' />
            </Segment>
        </Segment.Group>
    );
}